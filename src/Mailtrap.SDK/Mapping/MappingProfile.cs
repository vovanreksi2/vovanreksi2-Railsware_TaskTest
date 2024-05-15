using System.Globalization;
using AutoMapper;
using Mailtrap.SDK.MailtrapModels;

namespace Mailtrap.SDK.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Attachment, MTAttachment>();
        CreateMap<EmailAddress, MTEmailAddress>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(
                src => src.Email.ToLower(CultureInfo.InvariantCulture)));

        CreateMap<SendEmailRequest, MTSendEmailRequest>()
            .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.Recipients));

        CreateMap<MTResponse, BaseResponse>();
    }
}