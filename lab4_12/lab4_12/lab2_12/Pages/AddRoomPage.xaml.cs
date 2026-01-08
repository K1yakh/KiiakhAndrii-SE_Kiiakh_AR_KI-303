using System.Windows;
using System;
using lab2_12.api.Post;
using lab2_12.Entity;

namespace lab2_12.Pages;

public partial class AddRoomPage : Window
{
    public Room Room { get; set; }

    public AddRoomPage()
    {
        InitializeComponent();
        Room = new Room(0, 0);

        DataContext = this;
    }

    private void Close(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void AddRoomClick(object sender, RoutedEventArgs e)
    {
        var success = await RoomCreateService.Send(Room);
        if (success)
        {
            var main = new MainWindow();
            main.Show();
            Close();
            
        }
    }
}