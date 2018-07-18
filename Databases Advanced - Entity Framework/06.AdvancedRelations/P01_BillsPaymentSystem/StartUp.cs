using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Views;
using P01_BillsPaymentSystem.DbSeed;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new BillsPaymentSystemContext();

            //Seed(db);
            var userId = int.Parse(Console.ReadLine());
            var amount = decimal.Parse(Console.ReadLine());
            //PrintUserDetails(db, userId);
            PayBills(db, userId, amount);
        }

        private static void PayBills(BillsPaymentSystemContext db, int userId, decimal amount)
        {
            db.Database.BeginTransaction();

            var user = db.Users
                .Select(x => new
                {
                    UserId = x.UserId,
                    BankAccounts = x.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .OrderBy(b => b.BankAccountId)
                        .ToArray(),
                    CreditCards = x.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .OrderBy(c => c.CreditCardId)
                        .ToArray()
                })
                .FirstOrDefault(x => x.UserId == userId);

            if (user==null)
            {
                Console.WriteLine($"User with id {userId} does not exist");
                return;
            }

            if (!HaveMoney(user.BankAccounts,user.CreditCards,amount))
            {
                Console.WriteLine("Insufficient funds!");
                db.Database.RollbackTransaction();
                return;
            }

            foreach (var ba in user.BankAccounts)
            {
                ba.Withdraw(ref amount);
                if (amount==0)
                {
                    break;
                }
            }

            foreach (var cc in user.CreditCards)
            {
                cc.Withdraw(ref amount);
                if (amount==0)
                {
                    break;
                }
            }

            db.Database.CommitTransaction();
            db.SaveChanges();
        }

        private static bool HaveMoney(BankAccount[] bankAccounts, CreditCard[] creditCards, decimal amount)
        {
            return bankAccounts.Select(b => b.Balance).Sum() + creditCards.Select(c => c.LimitLeft).Sum() >= amount;
        }

        private static void PrintUserDetails(BillsPaymentSystemContext db, int userId)
        {
            var user = db.Users
                 .Where(u => u.UserId == userId)
                 .Select(u => new UserDetailsViews()
                 {
                     Name = $"{u.FirstName} {u.LastName}",
                     BankAccounts = u.PaymentMethods
                         .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                         .Select(pm => pm.BankAccount)
                         .ToArray(),
                     CreditCards = u.PaymentMethods
                         .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                         .Select(pm => pm.CreditCard)
                         .ToArray(),
                 })
                 .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
            }
            else
            {
                Console.WriteLine(user);
            }
        }
        private static void Seed(BillsPaymentSystemContext db)
        {
            db.Database.EnsureDeleted();

            db.Database.EnsureCreated();

            var seeder = new DbSeeder();
            seeder.Seed(db);
        }
    }
}
