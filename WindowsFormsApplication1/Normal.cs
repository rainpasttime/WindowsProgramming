using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;
using System.IO; 

namespace WindowsFormsApplication1
{
    public partial class Normal : Form
    {

        SoundPlayer music = new SoundPlayer();
        SoundPlayer sound = new SoundPlayer();

        const int MAX_WIDTH = 10;   // 列数
        const int MAX_HEIGHT = 10;  // 行数
        int[,] rightAnswer = new int[MAX_WIDTH, MAX_HEIGHT];  // 正确答案数组，里面的数只有0和1,0表示不点亮，1表示点亮
        int[,] userState = new int[MAX_WIDTH, MAX_HEIGHT]; // 用户状态数组，用户状态有4种，0表示未点开，1表示正确，2表示错误，3表示用户标记成为错误
        Button[,] button = new Button[MAX_WIDTH, MAX_WIDTH];//界面上的button数组
        bool chooseState = true;//取值是true的时候，选中下面判断点亮的按钮，取值是false的时候，选中下面判断是错的按钮
        bool isMusic = true;    //判断音乐是否打开的布尔值

        int bGame;          // 总共需要点亮的格子，判断游戏是否结束
        int life;      //总共可以错误的次数，判断游戏是否结束

        public Normal()//初始化一般版本的游戏界面
        {
            InitializeComponent();//系统自带的函生成数，初始化组件
            initButton();//按钮的生成，初始化按钮数组
            initRightAnswer();//初始化正确答案的数组
            initUserState();//初始化用户状态数组
        }
         //初始化用户状态数组
        private void initUserState()
        {
            int i;
            int j;
            for (i = 0; i < MAX_HEIGHT; i++)
            {
                for (j = 0; j < MAX_WIDTH; j++)
                {
                    userState[i, j] = 0;//置用户初始状态为0，代表灰色按钮界面
                }
            }
        }

        /*随机生成正确答案的函数
         * i,j,t都是用于循环的临时变量。
         * count是二维数组，用于存储每一行的提示数字和每一列的提示数字。
         * 注：count的行数是该游戏的行数，列数是该游戏的列数+1除以2
         * rd是一个Random类型的变量，用来产生随机数。
         * tag是标志，用于后面产生提示的时候进行格子是否连续的判断。   
         */
        private void initButton()
        {
            int i;
            int j;

            for (i = 0; i < MAX_WIDTH; i++)
            {
                for (j = 0; j < MAX_HEIGHT; j++)
                {
                    button[i,j] = new Button();
                    //为每一个数组成员指定宽度和高度
                    button[i, j].Width = 30;
                    button[i, j].Height = 30;
                    button[i, j].Tag = i * MAX_HEIGHT + j; //设置每个按钮的标签值，用于后面获得按钮的行和列数，进而进行响应点击事件
                    //定义第一个按钮的初始位置
                    if (Left < 33)
                    {
                        Left = 33;
                        Top = 25;
                    }
                    button[i,j].Left = Left;//把按钮放在指定位置
                    button[i, j].Top = Top;//把按钮放在指定位置
                    button[i, j].BackColor = Color.Gray;//将每个按钮的背影颜色置为黑色
                    //把按钮加入窗口
                    this.Controls.Add(button[i,j]);
                    //把下一个按钮的位置右移40像素
                    Left += 30;
                    //当Left大于200的时候，就要换行，则Left重置为33，Top加29
                    if (Left >= 328)
                    {
                        Left = 33;
                        Top += 29;
                    }
                    button[i, j].Click += buttonOne_Click;//给button数组添加统一的Click事件
                }
            }
        }
        /*
         * 初始化正确答案数组
         */
        public void initRightAnswer()
        {
            int i;
            int j;
            int t;
            int[,] count = new int[MAX_HEIGHT, MAX_WIDTH];  //右提示框数组（行）
            int[,] count1 = new int[MAX_HEIGHT, MAX_WIDTH];  //下提示框数组（列）
            //创建随机数对象
            Random rd = new Random();
            bool tag = true;   //用于判断是否是连续为1的格子
            bGame = 0;         //计算总共有多少没有判断为1的格子
            life = 5;          //剩余生命数

            //初始化时判断音乐是否需要打开
            if (isMusic)
            {
                music = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.ukulele_and_chill___Cody_G__wav);
                music.PlayLooping();     //让音乐循环播放
            }
            //初始化count数组为0     
            for (i = 0; i < MAX_HEIGHT; i++)
            {
                for (j = 0; j < MAX_WIDTH; j++)
                {
                    count[i, j] = 0;
                    count1[i, j] = 0;
                }   
            }
            /*
             * 生成随机数的循环
             * 生成随机数的同时要进行计数，生成提示数组。
             * tag为true表示之前那个格子的值也是1
             */
            for (i = 0; i < MAX_HEIGHT; i++)
            {
                t = 0;
                for (j = 0; j < MAX_WIDTH; j++)
                {
                    //生成随机数生成0或者生成1
                    rightAnswer[i, j] = rd.Next( 2);
                    button[i, j].BackColor = Color.Gray; //按钮的初始颜色为灰色
                    button[i, j].Image = null;          //按钮的初始Image为null
                    bGame += rightAnswer[i, j];         //计算正确答案的总数
                    //之前格子是1且现在这个格子是1的情况，则count[i,t]++
                    if (tag && rightAnswer[i, j] == 1)
                    {
                        count[i,t]++;
                     }
                    //之前格子是1，但是现在格子是0的情况，则tag置为false
                     else if (tag && rightAnswer[i, j] == 0)
                     {
                         tag = false;
                      }
                    //之前格子是0，但是现在格子是1，的情况，则说明又开始了另外一个连续的点亮的格子
                      else if (!tag && rightAnswer[i, j] == 1)
                      {
                          t++;
                          count[i,t]++;
                          tag = true;
                      }
                    //之前的格子是0并且现在也是0则不操作。
                }  
            }

            //初始化右提示框为空
            labelOne.Text = "";
            labelTwo.Text = "";
            labelThree.Text = "";
            labelFour.Text = "";
            labelFive.Text = "";
            labelSix.Text = "";
            labelSeven.Text = "";
            labelEight.Text = "";
            labelNine.Text = "";
            labelTen.Text = "";
           


            /*经过上面的for循环之后得到的count二维数组可以对界面上的提示的控件的Text进行赋值了。
             * labelOne到labelTen分别代表了界面上的第一行提示到第十行提示
             * 通过用toString方法把数组里面存储的数字转换成为字符，每转换一个数字就要添加一个空格，和后一个数字分隔开
             */
            for(j=0;j<MAX_HEIGHT;j++)
            {
                if (count[0, j] != 0)
                    labelOne.Text += count[0, j].ToString() + ' ';

                if (count[1, j] != 0)
                    labelTwo.Text += count[1, j].ToString() + ' ';

                if (count[2, j] != 0)
                    labelThree.Text += count[2, j].ToString() + ' ';

                if (count[3, j] != 0)
                    labelFour.Text += count[3, j].ToString() + ' ';

                if (count[4, j] != 0)
                    labelFive.Text += count[4, j].ToString() + ' ';
                if (count[5, j] != 0)
                    labelSix.Text += count[5, j].ToString() + ' ';

                if (count[6, j] != 0)
                    labelSeven.Text += count[6, j].ToString() + ' ';

                if (count[7, j] != 0)
                    labelEight.Text += count[7, j].ToString() + ' ';

                if (count[8, j] != 0)
                    labelNine.Text += count[8, j].ToString() + ' ';

                if (count[9, j] != 0)
                    labelTen.Text += count[9, j].ToString() + ' ';
                
            }

            /*
             *通过一个循环得到每一列的提示数组
             * 注：因为count数组是之前使用过的，所以里面的初值并不是0
             * 为了简便不再对count数组重新置0，而是先对count数组每一行中的一个元素置为0，进行循环
             * 当遇到tag=true的情况，就把后一个count单元置为0，方便后面按照是否等于0来判断是否停止循环
             */
            tag = true;
            for (j = 0; j < MAX_WIDTH; j++)
            {
                t = 0;
                count1[j, t] = 0;
                for (i = 0; i < MAX_HEIGHT; i++)
                {
                    if (tag && rightAnswer[i, j] == 1)
                    {
                        tag = true;
                        count1[j, t]++;
                    }
                    else if (tag && rightAnswer[i, j] == 0)
                    {
                        tag = false;
                    }
                    else if (!tag && rightAnswer[i, j] == 1)
                    {
                        t++;
                        count1[j, t]++;
                        tag = true;
                    }
                }
            }
           
            //初始化下提示框为空
            labelOneTwo.Text = "";
            labelTwoTwo.Text = "";
            labelThreeTwo.Text = "";
            labelFourTwo.Text = "";
            labelFiveTwo.Text = "";
            labelSixTwo.Text = "";
            labelSevenTwo.Text = "";
            labelEightTwo.Text = "";
            labelNineTwo.Text = "";
            labelTenTwo.Text = "";

            /*经过上面的for循环之后得到的count1二维数组可以对界面上的提示的控件的Text进行赋值了。
             * labelSix到labelTen分别代表了界面上的第一列提示到第五列提示
             * 通过用toString方法把数组里面存储的数字转换成为字符，每转换一个数字就要添加一个换行符，和后一个数字分隔开
             */
            for (j = 0; j < MAX_HEIGHT; j++)
            {
                if (count1[0, j] != 0)
                    labelOneTwo.Text += count1[0, j].ToString() + ' ';

                if (count1[1, j] != 0)
                    labelTwoTwo.Text += count1[1, j].ToString() + ' ';

                if (count1[2, j] != 0)
                    labelThreeTwo.Text += count1[2, j].ToString() + ' ';

                if (count1[3, j] != 0)
                    labelFourTwo.Text += count1[3, j].ToString() + ' ';

                if (count1[4, j] != 0)
                    labelFiveTwo.Text += count1[4, j].ToString() + ' ';
                if (count1[5, j] != 0)
                    labelSixTwo.Text += count1[5, j].ToString() + ' ';

                if (count1[6, j] != 0)
                    labelSevenTwo.Text += count1[6, j].ToString() + ' ';

                if (count1[7, j] != 0)
                    labelEightTwo.Text += count1[7, j].ToString() + ' ';

                if (count1[8, j] != 0)
                    labelNineTwo.Text += count1[8, j].ToString() + ' ';

                if (count1[9, j] != 0)
                    labelTenTwo.Text += count1[9, j].ToString() + ' ';
            }
        }

        //失去生命，设置相应图标不可见
        private void changeLifeImage()
        {
            if (life == 4)
                lifeOne.Visible = false;
            else if (life == 3)
                lifeTwo.Visible = false;
            else if (life == 2)
                lifeThree.Visible = false;
            else if (life == 1)
                lifeFour.Visible = false;
            else if(life==0)
                lifeFive.Visible = false;
            this.Refresh();
        }

        //用户点了一个button之后，改变相应button的图片，参数为1代表用户判断正确，0代表用户判断错误，否则用户标记为错误的
        private void changeButtonImage(int flag,int buttonX,int buttonY)
        {
            //设置button图片为正确
            if (flag==1)
            {
                button[buttonX,buttonY].BackColor = Color.Black;
            }
            //设置button图片为错误
            else if (flag == 0)
            {
                button[buttonX, buttonY].Image = WindowsFormsApplication1.Properties.Resources.radio5;    //设置按钮的图片为名字为radio5的红色叉
            }
            else
            {
                button[buttonX, buttonY].Image = WindowsFormsApplication1.Properties.Resources.judgeFalse5;  //设置按钮的图片为名字为judgeFalse5的蓝色叉
            }
            this.Refresh();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            int buttonX;      //临时变量，后面用于用于保存button的行坐标
            int buttonY;      //临时变量，后面用于用于保存button的列坐标
            Button send;     //临时的按钮变量，后面通过这个按钮保存发生点击事件的按钮


            sound = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.FC坦克大战战前BGM___群星);

            send = (Button)sender;                      //保存发生点击事件的按钮
            buttonX = (int)send.Tag / MAX_HEIGHT;      //通过button的Tag计算出这个button的行数
            buttonY = (int)send.Tag % MAX_HEIGHT;     //通过button的Tag计算出这个button的列数

            //如果生命值为0或者所有正确答案已经被点亮，就不作处理
            if (life == 0 || bGame == 0)
            {
                return;
            }
            //正确答案是要点亮，且用户确定这个格子是要点亮的
            else if (rightAnswer[buttonX, buttonY] != 0 && chooseState && userState[buttonX, buttonY] == 0)
            {
                userState[buttonX, buttonY] = 1;     //设置用户状态是正确
                bGame -= 1;                          //减少一个剩余需要点亮的格子
                changeButtonImage(1, buttonX, buttonY);     //改变相应button的图片
                if (bGame == 0)                 //当剩余需要点亮的格子为0
                {
                    if (isMusic)
                    {
                        sound.Play();             //放出游戏结束的提示音乐
                    }
                    MessageBox.Show("You Win!");   //跳出消息提示赢了
                    return;
                }
            }
            //用户判断不需要点亮
            else if (!chooseState && userState[buttonX, buttonY] == 0)
            {
                userState[buttonX, buttonY] = 3;          //设置用户标记错误
                changeButtonImage(2, buttonX, buttonY);   //改变相应button的图片
            }
            //正确答案不点亮，但是用户判断需要点亮
            else if (rightAnswer[buttonX, buttonY] == 0 && chooseState && userState[buttonX, buttonY] == 0)
            {
                userState[buttonX, buttonY] = 2;          //设置用户状态是错误
                life -= 1;                                //剩余生命数减一
                changeLifeImage();                        //改变显示生命值的图片
                changeButtonImage(0, buttonX, buttonY);   //改变相应button的图片
                if (life == 0)                            //当生命数值是0
                {
                    if (isMusic)
                    {
                        sound.Play();                     //放出游戏结束的提示音乐
                    }
                    MessageBox.Show("You Lose!");         //跳出消息提示输了
                }
            }
            //用户取消不点亮
            else if (!chooseState && userState[buttonX, buttonY] == 3)
            {
                userState[buttonX, buttonY] = 0;          //设置用户状态是未处理
                button[buttonX, buttonY].Image = null;    //改变相应button的图片为null
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            initRightAnswer();         //重置初始答案
            initUserState();            //重置用户状态为0
            lifeOne.Visible = true;     //显示全部生命值的图片
            lifeTwo.Visible = true;
            lifeThree.Visible = true;
            lifeFour.Visible = true;
            lifeFive.Visible = true;
        }

        //当用户点击音乐的按钮，对isMusic的值取反。
        private void button1_Click(object sender, EventArgs e)
        {
            if (isMusic == true)   //本来是打开的，则关闭，并且更换按钮的图片为已关闭音乐的图片
            {
                isMusic = false;
                music.Stop();
                button1.Image = WindowsFormsApplication1.Properties.Resources.musicwrong;
            }
            else       //本来是关闭的，则打开，并且更换按钮的图片为已打开音乐的图片
            {
                isMusic = true;
                music.PlayLooping();
                button1.Image = WindowsFormsApplication1.Properties.Resources.music_player_50_808510638298px_1201852_easyicon_net;
            }
        }

        //选择标记状态的按钮
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chooseState = true;
        }

        //选择标记状态的按钮
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chooseState = false;
        }

        //当这个窗口被关闭，关掉音乐
        private void Normal_FormClosing(object sender, FormClosingEventArgs e)
        {
            music.Stop();
        }

  

      

       

       
       
  
    }
}
