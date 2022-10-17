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

namespace JsonTextGenerator {
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>

    public class Question {
        public string question { get; set; }

        public string yes { get; set; }
        public Question postY { get; set; }

        public string no { get; set; }
        public Question postN { get; set; }

        public string maybe { get; set; }
        public Question postM { get; set; }
    }


    public partial class EditPage : Page {
        public Question que = new Question();


        public EditPage() {
            InitializeComponent();
            this.DataContext = que;
        }

        public void UpdateQuestion(Question que) {
            this.que = que;
            this.DataContext = que;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e) {
            string button = (e.OriginalSource as Button).Name;
            if (button.Contains("rem")) {
                if (button == "remY" && que.postY != null) {
                    this.que.postY = null;
                }
                else if(button == "remN" && que.postN != null) {
                    this.que.postN = null;
                }
                else if(que.postM != null){
                    this.que.postM = null;
                }

                VisibleChanged(null, new DependencyPropertyChangedEventArgs());
                return;
            }

            EditPage innerQuestion = new EditPage();
            
            if (button == "postY") {
                if (que.postY == null)
                    que.postY = innerQuestion.que;
                else
                    innerQuestion.UpdateQuestion(que.postY);
            }
            else if (button == "postN") {
                if (que.postN == null)
                    que.postN = innerQuestion.que;
                else
                    innerQuestion.UpdateQuestion(que.postN);
            }
            else{
                if (que.postM == null)
                    que.postM = innerQuestion.que;
                else
                    innerQuestion.UpdateQuestion(que.postM);
            }

            Manager.mainFrame.Navigate(innerQuestion);
        }

        private void VisibleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            postY.Content = que.postY == null ? "Create" : "Open";
            postN.Content = que.postN == null ? "Create" : "Open";
            postM.Content = que.postM == null ? "Create" : "Open";
        }
    }
}
