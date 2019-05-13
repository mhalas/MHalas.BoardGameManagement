using MHalas.BGM.Base.Enum;
using MHalas.BGM.Base.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace MHalas.BoardGameManagement.Models
{
    public class BoardGameLogViewModel
    {
        [Display(Name = "Date", ResourceType = typeof(BGM.l10n.Resource))]
        public DateTime Date { get; set; }

        [Display(Name = "BoardGameLogSource", ResourceType = typeof(BGM.l10n.Resource))]
        public string SourceAsString => Source.SourceToString();

        public ESource Source { get; set; }
    }
}