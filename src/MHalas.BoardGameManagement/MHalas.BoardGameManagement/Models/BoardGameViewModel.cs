using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MHalas.BoardGameManagement.Models
{
    public class BoardGameViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<BoardGameLogViewModel> BoardGameLogs { get; set; }

        [Display(Name = "Author", ResourceType = typeof(BGM.l10n.Resource))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(BGM.l10n.Resource))]
        public string Author { get; set; }

        [Display(Name = "Name", ResourceType = typeof(BGM.l10n.Resource))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(BGM.l10n.Resource))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(BGM.l10n.Resource))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(BGM.l10n.Resource))]
        public string Description { get; set; }

        [Display(Name = "PlayerMinimalAge", ResourceType = typeof(BGM.l10n.Resource))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(BGM.l10n.Resource))]
        public int PlayerMinimalAge { get; set; }
    }
}