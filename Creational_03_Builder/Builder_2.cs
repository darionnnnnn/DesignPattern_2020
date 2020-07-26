using System;
using System.Collections.Generic;
using System.Text;

namespace Creational_03_Builder
{
    public class Builder_2
    {
        public void Run()
        {
            CustomerBuilder builder = new CustomerBuilder();

            var customer = builder.SetUserName("Wayne")
                                  .SetEMail("Wayne@gmail.com")
                                  .SetPhoneNumber("0912345678")
                                  .GetConcrete();

            customer.Run();

            Console.ReadLine();
        }

        class CustomerBuilder
        {
            private string _UserName { get; set; }
            private string _EMail { get; set; }
            private string _PhoneNumber { get; set; }

            public CustomerBuilder SetUserName(string userName)
            {
                _UserName = userName;

                return this;
            }

            public CustomerBuilder SetEMail(string email)
            {
                _EMail = email;

                return this;
            }
            public CustomerBuilder SetPhoneNumber(string phoneNumber)
            {
                _PhoneNumber = phoneNumber;

                return this;
            }

            public Customer GetConcrete()
            {
                return new Customer(_UserName, _EMail, _PhoneNumber);
            }
        }

        class Customer
        {
            private string _UserName { get; }
            private string _EMail { get; }
            private string _PhoneNumber { get; }

            public Customer(string userName, string email, string phoneNumber)
            {
                _UserName = userName;
                _EMail = email;
                _PhoneNumber = phoneNumber;
            }

            public void Run()
            {
                Console.WriteLine($"UserName : {_UserName}");
                Console.WriteLine($"EMail : {_EMail}");
                Console.WriteLine($"PhoneNumber : {_PhoneNumber}");
            }
        }
    }
}
