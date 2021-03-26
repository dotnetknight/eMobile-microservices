using Common.Command;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace eMobile.Phones.Models.Commands
{
    public class UpdatePhoneCommand : ICommand
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }

        public JsonPatchDocument<UpdatePhoneCommand> JsonPatchDocument { get; set; }

        public UpdatePhoneCommand(JsonPatchDocument<UpdatePhoneCommand> jsonPatchDocument, Guid id)
        {
            JsonPatchDocument = jsonPatchDocument;
            Id = id;
        }
    }
}
