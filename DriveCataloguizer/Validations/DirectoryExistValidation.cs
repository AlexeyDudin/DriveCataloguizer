using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using DriveCataloguizerViewModel;

namespace DriveCataloguizer.Validations
{
    public class DirectoryExistValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is BindingExpression path && path.DataItem is DriveViewModel driveViewModel)
            {
                return Directory.Exists(driveViewModel.PathToDirectory) ? ValidationResult.ValidResult : new ValidationResult(false, "Путь не существует на данном компьютере!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
