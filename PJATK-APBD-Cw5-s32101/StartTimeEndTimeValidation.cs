using System.ComponentModel.DataAnnotations;
using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101;

public class StartTimeEndTimeValidation : ValidationAttribute
{
    public StartTimeEndTimeValidation()
    {
        ErrorMessage = "";
    }

    public override bool IsValid(object? value)
    {
        if (value is Reservation res)
        {
            if (res.StartTime >= res.EndTime)
            {
                ErrorMessage = "StartTime cannot be before or at EndTime";
                return false;
            }
        }
        return true;
    }
}