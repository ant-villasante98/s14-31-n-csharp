using System.ComponentModel.DataAnnotations;

namespace S14.QR.Commmon.Dtos;

public class QrCheckRequest
{
    [Required]
    public string Value { get; set; } = string.Empty;
}