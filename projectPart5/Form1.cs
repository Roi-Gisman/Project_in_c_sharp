using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectPart5
{
    //עדן לימן :207011644 רועי גיסמן :322355975
    public partial class FrnEcommers : Form
    {
        private Manager manager = new Manager("E-commerce");
        Seller seller;
        Buyer buyer;
        public FrnEcommers()
        {
            InitializeComponent();
            try
            {
                manager.LoadFile();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BTSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.AddBuyer(txtUsername.Text, txtPassword.Text, txtState.Text, txtCity.Text, txtStreet.Text, int.Parse(txtBuildingNumber.Text)))
                {
                    MessageBox.Show("buyer added");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("buyer is not add");
            }
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";
            txtBuildingNumber.Text = "";
            grbAddBuyer.Visible = false;
            grbMenu.Visible = true;
        }

        private void btlAddBuyer_Click(object sender, EventArgs e)
        {
            grbAddBuyer.Visible = true;
            grbMenu.Visible=false;
        }

        private void btnEnterToUser_Click(object sender, EventArgs e)
        {
            grbMenu.Visible = false;
            grbEnterUser.Visible = true;

        }

        private void btnCheckUser_Click(object sender, EventArgs e)
        {
            try
            {
                buyer = manager.IsExistBuyer(txtEnterUsername.Text, txtEnterPassword.Text);
                seller = manager.IsExistSeller(txtEnterUsername.Text, txtEnterPassword.Text);
                if (buyer != null)
                {
                    grbBuyer.Visible = true;
                    grbEnterUser.Visible = false;
                    txtEnterUsername.Text = "";
                    txtEnterPassword.Text = "";
                    UpdateCart();
                    UpdateAllProducts();
                }
                else if (seller != null)
                {
                    grbSeller.Visible = true;
                    grbEnterUser.Visible = false;
                    txtEnterUsername.Text = "";
                    txtEnterPassword.Text = "";
                    UpdateListSellerProducts();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("The user is not exist");
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void UpdateAllProducts()
        {
            lstProducts.Items.Clear();
            foreach (Seller seller in manager.Sellers)
            {
                foreach (Product product in seller.Products)
                {
                    lstProducts.Items.Add(product);
                }
            }
        }

        private void btnAddProductToCart_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = lstProducts.SelectedItem as Product;
                if (product != null)
                {
                    manager.addProductToCart(product, buyer.Username);
                    MessageBox.Show("Product added to your cart");
                    UpdateCart();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstSellerProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListSellerProducts();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblPricePacking_Click(object sender, EventArgs e)
        {

        }

        private void grbAddPriceForPacking_Enter(object sender, EventArgs e)
        {

        }

        private void rbtYSpecialPacking_CheckedChanged(object sender, EventArgs e)
        {
            grbAddBuyer.Visible = true;
        }

        private void grbMenu_Enter(object sender, EventArgs e)
        {

        }

        private void grbSeller_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            grbMenu.Visible = false;
            grbAddSeller.Visible = true;
        }

        private void grbAddSeller_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddSellerToSystem_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.AddSeller(txtUsernameSeller.Text, txtPasswordSeller.Text, txtStateSeller.Text, txtCitySeller.Text, txtStreetSeller.Text, int.Parse(txtBulidingSeller.Text)))
                {
                    MessageBox.Show("Seller added ro system");
                    txtUsernameSeller.Text = "";
                    txtPasswordSeller.Text = "";
                    txtStateSeller.Text = "";
                    txtCitySeller.Text = "";
                    txtBulidingSeller.Text = "";
                    grbAddSeller.Visible = false;
                    grbMenu.Visible = true;
                }
                else
                {
                    MessageBox.Show("Try agian");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try agian");

            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPricePacking.Text == null || txtPricePacking.Text == "")
                {
                    if (manager.addProductToSeller(seller.Username, txtProductName.Text, float.Parse(txtPrice.Text), ((Product.category)int.Parse(txtCategoryNum.Text))))
                    {
                        MessageBox.Show("The Product added");
                    }
                }
                else if (manager.addPackagingProductToSeller(seller.Username, txtProductName.Text, float.Parse(txtPrice.Text), ((Product.category)int.Parse(txtCategoryNum.Text)), float.Parse(txtPricePacking.Text)))
                {
                    MessageBox.Show("The Product added");
                    grbAddPriceForPacking.Visible = false;
                }
                else
                {
                    MessageBox.Show("The Product not added");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("The Product not added");
            }
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtCategoryNum.Text = "";
            txtPricePacking.Text = "";
            UpdateListSellerProducts();
        }

        private void btnYesPacking_Click(object sender, EventArgs e)
        {
            grbAddPriceForPacking.Visible = true;
        }
        private void UpdateListSellerProducts()
        {
            lstSellerProducts.Items.Clear();
            foreach (Product product in seller.Products)
            {
                lstSellerProducts.Items.Add(product);
            }

        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            grbMenu.Visible = true;
            grbSeller.Visible= false;
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtCategoryNum.Text = "";
        }

        private void btbMenu_Click(object sender, EventArgs e)
        {
            grbMenu.Visible = true;
            grbAddSeller.Visible= false;
            txtUsernameSeller.Text = "";
            txtPasswordSeller.Text = "";
            txtStateSeller.Text = "";
            txtCitySeller.Text = "";
            txtBulidingSeller.Text = "";

        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            grbMenu.Visible = true;
            grbEnterUser.Visible = false;
        }

        private void btnMenuReturn_Click(object sender, EventArgs e)
        {
            grbAddBuyer.Visible = false;
            grbMenu.Visible = true;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";
            txtBuildingNumber.Text = "";
        }

        private void lstCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateCart()
        {
            lstCart.Items.Clear();
            foreach (Product product in buyer.ShoppingCart)
            {
                if (product != null)
                {
                    lstCart.Items.Add(product);
                }
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            grbBuyer.Visible = false;
            grbMenu.Visible = true; 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order(buyer.Username, buyer.Address, buyer.ShoppingCart, manager.payment(buyer.Username));
                buyer.AddCartToCart(order);
            }
            catch (Exception)
            {
                MessageBox.Show("The order not added");

            }
            UpdateCart();
            UpdateAllProducts();
        }

        private void FrnEcommers_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            try
            {
                manager.SaveFile();
                MessageBox.Show("GooodBye!");
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNoPacking_Click(object sender, EventArgs e)
        {

        }

        private void txtPricePacking_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            float priceCart = manager.payment(buyer.Username);
            MessageBox.Show("The total price is:" + priceCart);
            lstCart.Items.Clear();
        }
    }
}
