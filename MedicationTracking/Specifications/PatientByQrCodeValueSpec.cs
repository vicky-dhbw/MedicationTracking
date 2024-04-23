using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class PatientByQrCodeValueSpec : Specification<QrCode>
{
   /// <summary>
   /// 
   /// </summary>
   /// <param name="qrCodeValue"></param>
   public PatientByQrCodeValueSpec(string qrCodeValue)
   {
      Query.Where(q => q.QrCodeValue == qrCodeValue);
   }
}