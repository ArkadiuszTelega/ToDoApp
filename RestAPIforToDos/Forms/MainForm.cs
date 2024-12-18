using Microsoft.EntityFrameworkCore;
using static RestAPIforToDos.Program;
using System.Threading.Tasks;
using RestAPIforToDos.Models;
using RestAPIforToDos.Controllers;
using RestAPIforToDos;

namespace RestAPIforToDos
{
    internal partial class MainForm : Form
    {
        private readonly ToDoManager toDoManager;

        public MainForm(ToDoManager toDoManager)
        {
            InitializeComponent();
            this.toDoManager = toDoManager;
            InitializeListView();
        }

        private void InitializeListView()
        {
            listViewToDos.View = View.Details;
            listViewToDos.FullRowSelect = true;

            listViewToDos.Columns.Add("Title", 150);
            listViewToDos.Columns.Add("Date Of Expiry", 100);
            listViewToDos.Columns.Add("Status", 150); // Adjust column width as needed
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            string title = titleBox.Text.Trim();
            string description = descriptionBox.Text;
            DateTime dateOfExpiry = todoTimePicker.Value;

            if (!string.IsNullOrEmpty(title))
            {
                ToDo newToDo = new (title, description, dateOfExpiry);
                await toDoManager.AddToDoAsync(newToDo);
                AddToDoToListView(newToDo);
            }
            else
            {
                MessageBox.Show("Please enter the title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            titleBox.Text = string.Empty;
            descriptionBox.Text = string.Empty;
            todoTimePicker.Value = DateTime.Now;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var toDos = await toDoManager.GetToDosAsync();
            ClearAndReloadListView(toDos);
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewToDos.SelectedItems.Count > 0)
            {
                var selectedItem = listViewToDos.SelectedItems[0];
                int? toDoId = selectedItem.Tag as int?;

                if (toDoId.HasValue)
                {
                    await toDoManager.DeleteToDoAsync(toDoId.Value);
                    listViewToDos.Items.Remove(selectedItem);
                }
                else
                {
                    MessageBox.Show("Invalid ToDo selected. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a ToDo to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listViewToDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewToDos.SelectedItems.Count > 0)
            {
                var selectedItem = listViewToDos.SelectedItems[0];
                int? toDoId = selectedItem.Tag as int?;

                if (toDoId.HasValue)
                {
                    var toDoItem = await toDoManager.GetToDoByIdAsync(toDoId.Value);

                    if (toDoItem != null)
                    {
                        txtboxUpdTitle.Text = toDoItem.Title;
                        txtboxUpdateDesc.Text = toDoItem.Description;
                        upDownComplete.Value = toDoItem.Complete;
                        timePickerUpd.Value = toDoItem.DateOfExpiry;
                        checkBoxDone.Checked = toDoItem.Done;
                    }
                }
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listViewToDos.SelectedItems.Count > 0)
            {
                var selectedItem = listViewToDos.SelectedItems[0];
                int? toDoId = selectedItem.Tag as int?;

                if (toDoId.HasValue)
                {
                    var toDoItem = await toDoManager.GetToDoByIdAsync(toDoId.Value);

                    if (toDoItem != null)
                    {
                        toDoItem.Title = txtboxUpdTitle.Text;
                        toDoItem.Description = txtboxUpdateDesc.Text;
                        toDoItem.DateOfExpiry = timePickerUpd.Value;
                        toDoItem.Done = checkBoxDone.Checked;
                        if (checkBoxDone.Checked)
                        {
                            toDoItem.Complete = 100;
                        }
                        else
                        {
                            toDoItem.Complete = (int)upDownComplete.Value;
                        }
                        await toDoManager.UpdateToDoAsync(toDoItem);

                        List<ToDo> toDos = await toDoManager.GetToDosAsync();
                        ClearAndReloadListView(toDos);

                        txtboxUpdTitle.Text = string.Empty;
                        txtboxUpdateDesc.Text = string.Empty;
                        upDownComplete.Value = 0;
                        timePickerUpd.Value = DateTime.Now;
                        checkBoxDone.Checked = false;
                    }
                }
            }
        }

        private void checkBoxDone_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxDone.Checked && listViewToDos.SelectedItems.Count > 0)
            {
                upDownComplete.Value = 100;
            }
        }

        private void upDownComplete_ValueChanged(object sender, EventArgs e)
        {
            if (upDownComplete.Value > 99 && !checkBoxDone.Checked)
            {
                checkBoxDone.Checked = true;
            }

            if (upDownComplete.Value < 100 && checkBoxDone.Checked)
            {
                checkBoxDone.Checked = false;
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            var toDos = context.ToDos.ToList();
            ClearAndReloadListView(toDos);
        }

        private async void buttonShowDone_Click(object sender, EventArgs e)
        {
            if (buttonShowDone.Text == "Show done")
            {

                List<ToDo> list = await toDoManager.GetDoneToDosAsync();
                ClearAndReloadListView(list);
                buttonShowDone.Text = "Show not done";
            }
            else
            {
                List<ToDo> list = await toDoManager.GetNotDoneToDosAsync();
                ClearAndReloadListView(list);
                buttonShowDone.Text = "Show done";
            }
        }

        private void ClearAndReloadListView(IEnumerable<ToDo> toDos)
        {
            listViewToDos.Items.Clear();
            foreach (var toDo in toDos)
            {
                AddToDoToListView(toDo);
            }
        }

        private void AddToDoToListView(ToDo toDo)
        {
            ListViewItem item = new ListViewItem(toDo.Title);
            item.SubItems.Add(toDo.DateOfExpiry.ToShortDateString());
            item.SubItems.Add(toDo.Done ? "Done" : $"{100 - toDo.Complete}% to be completed");
            item.Tag = toDo.Id;
            listViewToDos.Items.Add(item);
        }

        private async void todoCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var ToDos = await toDoManager.GetToDosRangeAsync(todoCalendar.SelectionStart, todoCalendar.SelectionEnd);
            ClearAndReloadListView(ToDos);
        }

        private async void buttonDone_Click(object sender, EventArgs e)
        {
            if (listViewToDos.SelectedItems.Count > 0)
            {
                var selectedItem = listViewToDos.SelectedItems[0];
                int? toDoId = selectedItem.Tag as int?;

                if (toDoId.HasValue)
                {
                    await toDoManager.MarkDoneToDoAsync(toDoId.Value);
                    var toDos = await toDoManager.GetToDosAsync();
                    ClearAndReloadListView(toDos);
                }
                else
                {
                    MessageBox.Show("Invalid ToDo selected. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a ToDo to mark as Done", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}