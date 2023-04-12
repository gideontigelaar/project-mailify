using System;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationHandler : MonoBehaviour
{
    // private void Start()
    // {
    //     Application.targetFrameRate = 120;

    //     var channel = new AndroidNotificationChannel()
    //     {
    //         Id = "channel_id",
    //         Name = "Notifications Channel",
    //         Importance = Importance.Default,
    //         Description = "Reminder notifications",
    //     };
    //     AndroidNotificationCenter.RegisterNotificationChannel(channel);

    //     DateTime now = DateTime.Now;
        
    //     if (now.Hour >= 10)
    //     {
    //         var notification1 = new AndroidNotification();
    //         notification1.Title = "Notification 1";
    //         notification1.Text = "It's 10:00!";
    //         notification1.FireTime = new DateTime(now.Year, now.Month, now.Day, 10, 0, 0);
    //         notification1.RepeatInterval = new TimeSpan(24, 0, 0);
    //         AndroidNotificationCenter.SendNotification(notification1, "channel_id");
    //     }

    //     if (now.Hour >= 18)
    //     {
    //         var notification2 = new AndroidNotification();
    //         notification2.Title = "Notification 2";
    //         notification2.Text = "It's 18:00!";
    //         notification2.FireTime = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);
    //         notification2.RepeatInterval = new TimeSpan(24, 0, 0);
    //         AndroidNotificationCenter.SendNotification(notification2, "channel_id");
    //     }
    // }
    private void Start()
    {
        Application.targetFrameRate = 120;
    
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    
        DateTime now = DateTime.Now;
    
        var notification1 = new AndroidNotification();
        notification1.Title = "Notification 1";
        notification1.Text = "It's 10:00!";
        notification1.FireTime = now.Hour >= 10 ? 
            new DateTime(now.Year, now.Month, now.Day, 10, 0, 0) : 
            new DateTime(now.Year, now.Month, now.Day, 10, 0, 0).AddDays(1);
        notification1.RepeatInterval = new TimeSpan(24, 0, 0);
        AndroidNotificationCenter.SendNotification(notification1, "channel_id");
    
        var notification2 = new AndroidNotification();
        notification2.Title = "Notification 2";
        notification2.Text = "It's 18:00!";
        notification2.FireTime = now.Hour >= 18 ? 
            new DateTime(now.Year, now.Month, now.Day, 18, 0, 0) : 
            new DateTime(now.Year, now.Month, now.Day, 18, 0, 0).AddDays(1);
        notification2.RepeatInterval = new TimeSpan(24, 0, 0);
        AndroidNotificationCenter.SendNotification(notification2, "channel_id");
    }
}
