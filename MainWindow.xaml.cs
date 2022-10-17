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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;

namespace JsonTextGenerator {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static EditPage mainPage = new EditPage();

        public MainWindow() {
            InitializeComponent();

            Manager.mainFrame = mainFrame;
            Manager.mainFrame.Navigate(mainPage);
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e) {
            string button = (e.OriginalSource as Button).Name;
            if (button == "backButton" && Manager.mainFrame.CanGoBack)
                Manager.mainFrame.GoBack();
            else if(button == "saveButton"){
                var options = new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Always };
                string json = JsonSerializer.Serialize(mainPage.que, options);
                File.WriteAllText("text.json", json);
            }
        }


    }
}
