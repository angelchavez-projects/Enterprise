using Enterprise.Application.Wrappers.Enums;

namespace Enterprise.Application.Wrappers
{
    public class Error(ErrorCode errorCode, string description, string fieldName)
    {
        public ErrorCode ErrorCode { get; set; } = errorCode;
        public string FieldName { get; set; } = fieldName;
        public string Description { get; set; } = description;
    }
}
