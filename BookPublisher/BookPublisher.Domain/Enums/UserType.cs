using System.Runtime.Serialization;

namespace BookPublisher.Domain.Enums
{
    [DataContract]
    public enum UserType
    {
        [EnumMember(Value = "ADMINISTRATOR")]
        ADMINISTRATOR = 0,
        [EnumMember(Value = "EMPLOYEE")]
        EMPLOYEE = 1
    }
}