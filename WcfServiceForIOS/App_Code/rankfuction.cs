using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// rankfuction 的摘要说明
/// 计算帖子得分和评论的得分
/// </summary>
public class rankfuction

{
       
    private static DateTime Tcreat=Convert.ToDateTime("2013-10-01 00:00:00");
	public rankfuction()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private static int Timepass(DateTime Ts, DateTime Tnow) {
        TimeSpan T;
        T = Tnow.Subtract(Ts);
        string t;
        t = T.TotalSeconds.ToString();
        int intt;
        intt = Convert.ToInt32(t);
        //intt = intt - 1134028003;
        return intt;

    }
    private static int Updown(int up, int down) {
        int cha;
        cha = up - down;
        return cha;

    }



    private static int Yfunction(int x) {

        if (x > 0) {
            return 1;
        }
        else if (x < 0) {
            return -1;
        }
        else {
            return 0;
        }
    }

    private static int Zfunction(int x) {

        if (Math.Abs(x) >= 1) {
            return Math.Abs(x);
        }
        else {
            return 1;
        }
    }

    private static double fmain(int timepass, int yfunction, int zfunction) {

        double temp = 0;
        temp = Math.Log10((double)zfunction) + (yfunction * timepass / 45000f);
        return temp;
    }

    /// <summary>
    /// Get the poster's rank scores
    /// </summary>
    /// <param name="Ups"></param>
    /// <param name="Downs"></param>
    /// <param name="Tcreat"></param>
    /// <param name="Tnow"></param>
    /// <returns></returns>
    public static double Hotfunction(int Ups,int Downs,DateTime Tnow) {
        double hot = 0; 
        int timepass = Timepass(Tcreat, Tnow);
        int votecha = Updown(Ups, Downs);
        int y = Yfunction(votecha);
        int z = Zfunction(votecha);
        hot = fmain(timepass, y, z);
        return hot;
    
    }

 //-----------------------------------The comment calcualte --------------------------------------------//
    private static  double Comentf(double phat, double n, double z) {
        double comentsort = (phat + z * z / (2 * n) - z * Math.Sqrt((phat * (1 - phat) + z * z / (4 * n)) / n)) / (1 + z * z / n);
        return comentsort;
    }
    private static double fPhat(int ups, int downs) {

        double temp = (double)ups / (ups + downs);
        return temp;
    }
    private static  int Sumvotes(int ups, int downs) {
        return (ups + downs);
    }

    /// <summary>
    /// Get the coment's scores
    /// </summary>
    /// <param name="Ups"></param>
    /// <param name="Downs"></param>
    /// <returns></returns>
    public static  double Comentfunction(int Ups,int Downs) {
        double z = 1.0f;//1.0=85%   1.6=95% z统计量
        double phat = fPhat(Ups, Downs);
        double n = Sumvotes(Ups, Downs);
        double comentscores = Comentf(phat, n, z);
        return comentscores;
    
    }
   
}