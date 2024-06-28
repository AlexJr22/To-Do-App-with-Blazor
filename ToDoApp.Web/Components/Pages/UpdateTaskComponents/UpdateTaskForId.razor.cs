using Microsoft.AspNetCore.Components;
using ToDoApp.Web.Model;

namespace ToDoApp.Web.Components.Pages.UpdateTaskComponents
{
    public partial class UpdateTaskForId
    {
        [Parameter]
        public int id { get; set; }
        [Parameter]
        public string? NewNameOfResponsible { get; set; }
        [Parameter]
        public string? NewTaskTittle { get; set; }
        private TodoItem task = new();

        private async Task UpdateResponsible()
        {
            if (NewNameOfResponsible is not null)
                await client.UpdateNameResponsible(id, NewNameOfResponsible);
        }

        private async Task UpdateTitle()
        {
            if(NewTaskTittle is not null)
                await client.UpdateTitle(id, NewTaskTittle);
        }

        private async Task ClickToUpdate()
        {
            await UpdateResponsible();
            await UpdateTitle();
        }

        protected override async Task OnInitializedAsync()
        {
            task = await client.GetTaskForId(id);
        }
    }
}
