using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Exceptions
{
    public class ExceptionMessage
    {
        public const string NameAlreadyUsed = "Illegal name. Provided one might be already used."; 
        public const string NoChanges = "Nothing has been changed. Operation cancelled."; 
        public const string IncorrectId = "Illegal id. Entity with this id does not exist."; 
        public const string UpdateFailed = "Could not update entity in the database."; 
        public const string DeleteFailed = "Could not delete entity in the database."; 
        public const string AddFailed = "Could not add entity in the database."; 
        public const string SavingChangesFailed = "Could not save changes in the database."; 
    }
}
