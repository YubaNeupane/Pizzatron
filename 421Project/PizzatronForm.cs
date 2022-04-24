using System.Diagnostics;
using MainProgram;
using Toppings;
using Utility;
using System.Windows;
using Stores;

namespace _421Project
{
    public partial class PizzatronForm : Form
    {
        OrderingMachine orderingMachine;
        Dictionary<string,bool> selectedToppings = new Dictionary<string,bool>();
        ListViewItem? selectedItem;


        public PizzatronForm()
        {
            InitializeComponent();
            orderingMachine = new OrderingMachine(mainProgressbar);

            displayMenu();

        }

        private void DisplayFilterItems(string filterItem)
        {
            toppingListView.Items.Clear();

            foreach (ToppingFromFile topping in orderingMachine.getFilteredToppings(filterItem.Split(" ")[0]))
            {
                ListViewItem listViewItem = new ListViewItem("");
                listViewItem.SubItems.Add(topping.Name);



                String types = "";
                foreach (String type in topping.type)
                {
                    types += " " + type;
                }
                listViewItem.SubItems.Add(types);
                listViewItem.SubItems.Add(topping.price.ToString("C2"));


                toppingListView.Items.Add(listViewItem);
            }
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

        private void updatePrice()
        {
            double[] price = orderingMachine.getPrice();
            lblSubtotal.Text = price[0].ToString("C2");
            lblTax.Text = price[1].ToString("C2");
            lblTotalCost.Text = price[2].ToString("C2");
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
            if(selectedItemList.Items.Count == 0)
            {
                btnDoneSelecting.Enabled = false;

            }
        }
        private void updateShoppingCartTopping()
        {
            shoppingChartPizzaName.Text = orderingMachine.getSelctedPizzaBase().Name.ToString().ToUpper();
            shoppingCartListBox.Items.Clear();
            foreach (KeyValuePair<string, bool> item in selectedToppings)
            {
                String output = item.Key;
                output += item.Value ? "\t(E)" : "";
                shoppingCartListBox.Items.Add(output);
            }
            if (selectedItemList.Items.Count == 1)
            {
                btnShoppingCartToppingRemove.Enabled = false;

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
                btnDoneSelecting.Enabled = true;
            }
            toppingListView.SelectedItems.Clear();
            updateSelectedTopping();
        }

        private void selectedItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedItemList.SelectedItems.Count >= 1)
            {
                btnRemoveSelectedItem.Enabled = true;
            }
            else
            {
                btnRemoveSelectedItem.Enabled = false;
            }
        }

        private void btnRemoveSelectedItem_Click(object sender, EventArgs e)
        {
            string selectedItem = selectedItemList.Text.ToString();
            if(selectedItem.IndexOf("(") > 0)
            {
                selectedItem = selectedItem.Substring(0, selectedItem.IndexOf("(")).Trim();
            }
            else
            {
                selectedItem = selectedItem.Trim();
            }
            selectedToppings.Remove(selectedItem);
            updateSelectedTopping();
            btnRemoveSelectedItem.Enabled = false;
        }

        private void orderPizza()
        {
            orderingMachine.createPizza(orderingMachine.getSelctedPizzaBase().Name);
            foreach (KeyValuePair<string, bool> item in selectedToppings)
            {
                orderingMachine.addTopingToPizza(item.Key, item.Value);
            }
            updatePrice();
        }

        private void btnDoneSelecting_Click(object sender, EventArgs e)
        {

            
            mainTabControl.SelectedIndex = 1;
            pizzaTabMenu.Enabled = false;

            updateShoppingCartTopping();
            orderPizza();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 0;
            pizzaTabMenu.Enabled = true;
            pizzaTabMenu.SelectTab(0);
            updateSelectedPizzaBase();
            selectedToppings.Clear();
            updateSelectedTopping();
            updateShoppingCartTopping();
            orderingMachine.createPizza("");
            updatePrice();
            filterDropDownMenu.Text = "None";

        }

        private void btnShoppingCartToppingRemove_Click(object sender, EventArgs e)
        {
            string selectedItem = shoppingCartListBox.Text.ToString();
            if (selectedItem.IndexOf("(") > 0)
            {
                selectedItem = selectedItem.Substring(0, selectedItem.IndexOf("(")).Trim();
            }
            else
            {
                selectedItem = selectedItem.Trim();
            }
            selectedToppings.Remove(selectedItem);
            updateShoppingCartTopping();
            orderPizza();
        }

        private void shoppingCartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shoppingCartListBox.Items.Count <= 1)
            {
                btnShoppingCartToppingRemove.Enabled = false;
            }
            else
            {
                btnShoppingCartToppingRemove.Enabled = true;

            }
        }

        private void filterDropDownMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            DisplayFilterItems(filterDropDownMenu.Text);
        }

        private void storeComboBox_TextChanged(object sender, EventArgs e)
        {
            lblWaitTime.Text = orderingMachine.selectStore(storeComboBox.Text)?.getWaitTime() + " Min";
            btnBuyNow.Enabled = true;
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            pnalOrderHider.Visible = false;
            btnPay.Enabled = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string cardNumber = txtCardNumber.Text;
            string cvcNumber = txtCVC.Text;
            if (firstName.Length > 0 && lastName.Length > 0 && address.Length > 0 && phoneNumber.Length == 14 && cardNumber.Length == 19 && cvcNumber.Length == 3)
            {
                Debug.WriteLine(firstName);
                Debug.WriteLine(lastName);
                Debug.WriteLine(address);
                Debug.WriteLine(phoneNumber);
                Debug.WriteLine(cardNumber);
                Debug.WriteLine(cvcNumber);
                orderingMachine.orderPizza(firstName, lastName, address, phoneNumber, cardNumber, cvcNumber);

            }
            else
            {
                MessageBox.Show("Invalid user input!\nTry Again...", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void clearUserInput()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            txtCardNumber.Text = "";
            txtCVC.Text = "";
        }

        private void btnClearUserInput_Click(object sender, EventArgs e)
        {
            clearUserInput();
        }
    }
}