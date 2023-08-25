using System.ComponentModel.DataAnnotations;

namespace HETech.Domain.Enums
{
    public enum Permissoes
    {
        [Display(Name = "Usuario")]
        Usuario = 1,
        [Display(Name = "Admin")]
        Admin = 2
    }
}
