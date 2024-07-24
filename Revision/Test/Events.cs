using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    
    public class Activity
    {
        private int experience;

        //public delegate void AchievementUnlockedHandler(int point);
        //public event AchievementUnlockedHandler AchievementCompleted;
        public event Action<int> AchievementCompleted;
        public Activity(int _exp = 0)
        {
           experience = _exp;
        }
        public void IncreaseExperience(int _exp)
        {
            experience = experience + _exp;
            Console.WriteLine($"Current points : {experience}");
            if (experience > 100)
            {
                AchievementCompleted.Invoke(experience);
            }
        }
    }
    internal class Events
    {
        public void MainFunction()
        {
            Activity ob = new Activity();
            
            TriggeredActivity triggeredActivity = new TriggeredActivity();
            //Subscribe to event
            ob.AchievementCompleted += triggeredActivity.ExperienceUnlocked;

            // Events defined in same class
            ob.AchievementCompleted += OnAchievementUnlocked;

            ob.IncreaseExperience(10);
            ob.IncreaseExperience(20);
            ob.IncreaseExperience(30);
            ob.IncreaseExperience(90);

            ob.IncreaseExperience(200);

            //UnSubscribe to event
            ob.IncreaseExperience(200);

            ob.AchievementCompleted -= OnAchievementUnlocked;

            ob.AchievementCompleted -= triggeredActivity.ExperienceUnlocked;
        }

        private void OnAchievementUnlocked(int point)
        {
            Console.WriteLine($"Congratulations, you did it!, you have {point}");
        }
    }
    public class TriggeredActivity
    {
        public void ExperienceUnlocked(int point)
        {
            Console.WriteLine($"New level unlocked {point}");
        }
    }
}
