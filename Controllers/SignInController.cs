using HouseRentAndSaleWebApp.DB.Entites;
using HouseRentAndSaleWebApp.Models;
using ImmovablesSales.DB;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace HouseRentAndSaleWebApp.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]  //  new account creation, post request
        public IActionResult CreateAccount(SignUpViewModel model)
        {
            if (model.pass1 != model.pass2)
                return SignUpFail(model, "Паролі у полях не сходяться");

            if (model.login.Length < 5)
                return SignUpFail(model, "Логін має бути від 5 символів");

            if (model.pass1.Length < 8)
                return SignUpFail(model, "Пароль має бути від 8 символів");

            List<string> PIB = model.pib.Split(' ').ToList();
            PIB.RemoveAll(string.IsNullOrWhiteSpace);

            if (PIB.Count < 3)
                return SignUpFail(model, "Введіть повний ПІБ");

            if (model.phone.Length < 7 || model.phone.Any(x => !char.IsDigit(x)))
                return SignUpFail(model, "Перевірте номер телефону");

            if (!model.email.Contains('@') || !model.email.Contains('.') || model.email.Count(x => x == '@') > 1)
                return SignUpFail(model, "Перевірте коректність Email");

            using (Context context = new Context())
            {
                if (context.Users.Any(x => x.login == model.login))
                    return SignUpFail(model, "Логін зайнято");

                if (context.Users.Any(x => x.phone == model.phone))
                    return SignUpFail(model, "Номер телефону зайнято");

                if (context.Users.Any(x => x.email == model.email))
                    return SignUpFail(model, "Цей Email вже використовується");

                string pass_hash = GetHash(model.pass1); ;

                UserEntity newUser = new UserEntity
                {
                    login = model.login,
                    phone = model.phone,
                    email = model.email,
                    PIB = model.pib,
                    pass = pass_hash
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }

            return View("SignIn", new SignInViewModel { form_message = "Обліковий запис створено" });
        }

        public IActionResult SignUpFail(SignUpViewModel model, string message)
        {   //  failed account creation, return view and message why
            model.error_mes = message;
            return View("SignUp", model);
        }

        static string GetHash(string input)
        {
            byte[] data;
            using (SHA256 sha256 = SHA256.Create())
            {
                data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        [HttpPost]  //  try to enter to account
        public IActionResult TryLogin(SignInViewModel model)
        {
            using (Context context = new Context())
            {
                UserEntity? user = context.Users.FirstOrDefault(x => x.login == model.login && x.pass == GetHash(model.pass));
                if (user == null) 
                {
                    model.form_message = "Користувача не знайдено";
                    model.form_massage_color = "Red";
                    return View("SignIn", model);
                }

                Response.Cookies.Append("u", user.Id.ToString(),
                new CookieOptions
                {
                    Secure = true,
                    Expires = DateTime.Now.AddDays(7)
                }
                );
            }

            return View("SignIn", new SignInViewModel { form_message = "Вхід успішний" });
        }
    }
}
