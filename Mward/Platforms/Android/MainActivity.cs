using Android.App;
using Android.OS;

[Activity(Label = "Mward", MainLauncher = true)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Firebase.FirebaseApp.InitializeApp(this);
    }
}
