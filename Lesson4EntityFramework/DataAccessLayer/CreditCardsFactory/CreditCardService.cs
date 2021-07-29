using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer.CreditCardsFactory
{
    public interface ICreditCardService
    {
        public void MakeTransaction(int amount);        
    }

    public interface IGiftCardService
    {
        public void MakeGift();
    }

    public class CreditCardService : ICreditCardService
    {
        public virtual void MakeTransaction(int amount)
        {
            //make transaction with amount from card to card
        }
    }

    public class VisaCardService : CreditCardService
    {
        public virtual void MakeTransaction(int amount)
        {
            //make transaction with VISA card
        }
    }

    public class MasterCardService : CreditCardService
    {
        public virtual void MakeTransaction(int amount)
        {
            //make transaction with Master card
        }
    }
}
