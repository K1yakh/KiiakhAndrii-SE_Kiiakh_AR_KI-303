using System.Collections.ObjectModel;
using System.Windows;
using lab2_12.api.Get;
using lab2_12.api.Post;
using lab2_12.Entity;

namespace lab2_12.Pages;

public partial class GetInfo : Window
{
    public ObservableCollection<Review> Reviews { get; set; }
    public Room Room { get; set; }

    public GetInfo(Room room)
    {
        InitializeComponent();
        Reviews = new ObservableCollection<Review>();
        Room = room;
        GetReviewsFromServer();

        DataContext = this;
    }

    private async void GetReviewsFromServer()
    {
        try
        {
            var (success, reviews) = await GetReviews.Send(Room.Id);
            if (success) 
            {
                Reviews.Clear();
                foreach (var review in reviews)
                {
                    Reviews.Add(review);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error fetching reviews from server: {ex.Message}");
            Reviews = new ObservableCollection<Review>();
        }
    }

    private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
    {
        var success = await RoomUpdateService.Send(Room);
        if (success)
        {
            Close();
        }
    }

    private async void AddReviewButton_Click(object sender, RoutedEventArgs e)
    {
        string reviewText = ReviewTextBox.Text?.Trim();
        
        if (string.IsNullOrEmpty(reviewText))
        {
            MessageBox.Show("Будь ласка, введіть текст відгуку.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var (success, message) = await AddReviewService.Send(Room.Id, reviewText);
            
            if (success)
            {
                MessageBox.Show("Відгук успішно додано!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                ReviewTextBox.Text = string.Empty;
                
                // Оновлюємо список відгуків
                GetReviewsFromServer();
            }
            else
            {
                MessageBox.Show($"Помилка при додаванні відгуку: {message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка при додаванні відгуку: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}