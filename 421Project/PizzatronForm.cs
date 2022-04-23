using System.Diagnostics;
using MainProgram;
using Toppings;
using Utility;

namespace _421Project
{
    public partial class PizzatronForm : Form
    {
        OrderingMachine orderingMachine;
        Dictionary<string,bool> selectedToppings = new Dictionary<string,bool>();
        ListViewItem? selectedItem;

        public PizzatronForm()
        {
            orderingMachine = new OrderingMachine();
            InitializeComponent();

            displayMenu();

        }

        private void displayMenu()
        {

            listPizzaBaseMenu.Items.Clear();
            foreach(PizzaBaseFromFile pizzaItem in orderingMachine.getPizzaBaseFromFile())
            {
                ListViewItem listViewItem = new ListViewItem(pizzaItem.Name);
                listViewItem.SubItems.Add(pizzaItem.price.ToString("C2"));

                listPizzaBaseMenu.Items.Add(listViewItem);
             
            }

            toppingListView.Items.Clear();
            
            foreach(ToppingFromFile topping in orderingMachine.getToppingFromFile())
            {
                ListViewItem listViewItem = new ListViewItem("");
                listViewItem.SubItems.Add(topping.Name);



                String types = "";
                foreach(String type in topping.type)
                {
                    types += " " + type;
                }
                listViewItem.SubItems.Add(types);
                listViewItem.SubItems.Add(topping.price.ToString("C2"));


                toppingListView.Items.Add(listViewItem);
            }
        }


        private void updateSelectedPizzaBase()
        {
            PizzaBaseFromFile pizzaBaseFromFile = orderingMachine.getSelctedPizzaBase();
            lblSelectedBasePizza.Text = pizzaBaseFromFile.Name + " \n" + pizzaBaseFromFile.price.ToString("C2");
            selectedPizzaLabelGroup.Text = pizzaBaseFromFile.Name.ToUpper();
        }

        private void updateSelectedTopping()
        {
            selectedItemList.Items.Clear();
            foreach (KeyValuePair<string, bool> item in selectedToppings)
            {
                String output = item.Key;
                output += item.Value ? "\t(E)" : "";
                selectedItemList.Items.Add(output);
            }
        }

        private void listPizzaBaseMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listPizzaBaseMenu.SelectedIndices.Count == 1)
            {
                orderingMachine.setSelectedPizzaBase(listPizzaBaseMenu.SelectedIndices[0]);
                updateSelectedPizzaBase();
                toppingPanel.Enabled = true;
            }
            else
            {
                toppingPanel.Enabled = false;
            }
        }

        private void toppingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toppingListView.SelectedIndices.Count >= 1)
            {
                selectedItem = toppingListView.SelectedItems[toppingListView.SelectedIndices.Count - 1];

                btnSelectToppingItem.Enabled = true;
            }
            else
            {
                btnSelectToppingItem.Enabled = false;
                selectedItem = null;
            }
        }

        private void btnSelectToppingItem_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;
            string name = selectedItem.SubItems[1].Text;
            bool isExtra = selectedItem.Checked;
            if (selectedToppings.ContainsKey(name))
            {
                selectedToppings[name] = isExtra;
            }
            else
            {
                selectedToppings.Add(name, isExtra);
            }
            toppingListView.SelectedItems.Clear();
            updateSelectedTopping();
        }
    }
}