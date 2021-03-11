using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentDomain.Models.Enums
{
    public enum SubscriptionStatus
    {
        Cancelled, //Отменена пользователем
        Active, //Активная подписка
        NotPaid, //Подписка активна, но не оплачена
        Removed //Отменена Автором
    }
}
