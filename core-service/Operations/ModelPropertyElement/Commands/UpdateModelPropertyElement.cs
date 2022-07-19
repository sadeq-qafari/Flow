using Core.Meteor;
using Core.Operations.ModelPropertyElement.Dto;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class UpdateModelPropertyElement : DbUpdateAsync<UpdateModelPropertyElementInDto>
    {
        public UpdateModelPropertyElement() : base("[Core].[ModelPropertyElement]",
            "[Name]=@Name, [Type]=@Type, [Attributes]=@Attributes")
        {
        }
    }
}
