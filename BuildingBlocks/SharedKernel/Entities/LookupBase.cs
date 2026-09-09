using BuildingBlocks.SharedKernel.Entities;

namespace SharedKernel.Entities;

public abstract class LookupBase : BaseEntity
{
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; }
}