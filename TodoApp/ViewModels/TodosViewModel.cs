using System.Collections.Generic;

namespace TodoApp.ViewModels
{
    public class TodosViewModel
    {
        public List<TodoViewModel> Pendentes { get; set; }

        public List<TodoViewModel> EmAndamento { get; set; }

        public List<TodoViewModel> Finalizado { get; set; }
    }
}
