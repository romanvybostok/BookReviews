using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookReviews
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookModel b = new BookModel();

            b.BookName = bookNameValue.Text;
            b.AuthorName = bookAuthorValue.Text;
            b.PublishYear = publishYearValue.Text;
            b.Rating = ratingValue.Text;
            b.UserDescription = descriptionValue.Text;
            b.UserThoughts = userThoughtsValue.Text;

            GlobalConfig.Connection.CreateBook(b);

            bookNameValue.Text = "";
            bookAuthorValue.Text = "";
            publishYearValue.Text = "";
            ratingValue.Text = "";
            descriptionValue.Text = "";
            userThoughtsValue.Text = "";
        }
    }
}
