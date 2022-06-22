using Core.Operations.ModelPropertyElement.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class UpdateModelPropertyElement : SaanaaDbUpdateAsync<UpdateModelPropertyElementInDto>
    {
        public UpdateModelPropertyElement() : base("[Core].[ModelPropertyElement]",
            "[Name]=@Name, [Type]=@Type, [Attributes]=@Attributes")
        {
        }
    }
}
