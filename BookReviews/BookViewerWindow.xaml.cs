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
    /// Interaction logic for BookViewerWindow.xaml
    /// </summary>
    public partial class BookViewerWindow : Window
    {
        List<BookModel> books = GlobalConfig.Connection.GetBook_All();
        public BookViewerWindow()
        {
            InitializeComponent();

            WireUpComboBox();
        }

        private void WireUpComboBox()
        {
            selectBookComboBox.ItemsSource = books;
            selectBookComboBox.DisplayMemberPath = "BookName";
        }

        private void WireUpLists()
        {
            BookModel selectedBook = (BookModel)selectBookComboBox.SelectedItem;

            bookNameVal.Text = selectedBook.BookName;
            authorNameVal.Text = selectedBook.AuthorName;
            yearPublishedVal.Text = selectedBook.PublishYear;
            ratingVal.Text = selectedBook.Rating;
            userDescriptionVal.Text = selectedBook.UserDescription;
            userThoughtsVal.Text = selectedBook.UserThoughts;
        }

        private void selectBookComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WireUpLists();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            BookModel b = (BookModel)selectBookComboBox.SelectedItem;

            b.BookName = bookNameVal.Text;
            b.AuthorName = authorNameVal.Text;
            b.PublishYear = yearPublishedVal.Text;
            b.Rating = ratingVal.Text;
            b.UserDescription = userDescriptionVal.Text;
            b.UserThoughts = userThoughtsVal.Text;

            GlobalConfig.Connection.UpdateBook(b);

            MessageBox.Show("The book has been updated.");
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            BookModel b = (BookModel)selectBookComboBox.SelectedItem;

            GlobalConfig.Connection.DeleteBook(b);

            MessageBox.Show("The book has been deleted");
        }
    }
}
