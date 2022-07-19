using Core.Meteor;

namespace Flow.Operations.FormProperty.Commands
{
    public class FormPropertyRemove : DbDeleteAsync
    {
        public FormPropertyRemove() : base("[Flow].[FormProperty]")
        {
        }
    }
}