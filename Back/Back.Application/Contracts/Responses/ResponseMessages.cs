using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Contracts.Responses
{
    /// <summary>
    /// Class contains all constant messages dedicated to user.
    /// </summary>
    public class ResponseMessages
    {
        public const string SucceedRequest = "Successfully proceed request";
        public const string SuccessfullyAdded = "Successfully added entity";
        public const string SuccessfullyDeleted = "Successfully deleted entity";
        public const string SuccessfullyModified = "Successfully modified entity";

        public const string NotExist = "Entity does not exist";
        public const string IncorrectId = "Incorrect entity id";
        public const string NameAlreadyUsed = "Name is already used";
        public const string Unknown = "Unrecognized issue";
    }
}
