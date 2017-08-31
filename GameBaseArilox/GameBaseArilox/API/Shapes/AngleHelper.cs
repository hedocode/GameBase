using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    public static class AngleHelper
    {
        /*PI VALUES*/
        public const double PiD = 3.1415926535897931;
        public const float PiF = 3.14159264f;

        /*DEGREE CONVERSIONS*/
        public static float DegreeToRadian(float degrees)
        {
            return degrees * (PiF / 180);
        }

        public static float DegreeToTurn(float degrees)
        {
            return degrees/360;
        }

        public static float DegreeToGradian(float degrees)
        {
            return degrees / 0.9f;
        }

        public static Vector2 DegreeToVector(float degrees, float vectorLenght)
        {
            return RadianToVector(DegreeToRadian(degrees), vectorLenght);
        }

        /*RADIAN CONVERSIONS*/
        public static float RadianToDegree(float radians)
        {
            return radians * (180 / PiF);
        }

        public static float RadianToTurn(float radians)
        {
            return radians/2;
        }

        public static float RadianToGradian(float radians)
        {
            return radians*200;
        }

        public static Vector2 RadianToVector(float radians, float vectorLenght)
        {
            return new Vector2(vectorLenght*(float) Math.Cos(radians), -vectorLenght*(float) Math.Sin(radians));
        }

        /*TURN CONVERSIONS*/
        public static float TurnToDegree(float turn)
        {
            return turn*360;
        }

        public static float TurnToRadian(float turn)
        {
            return turn*2;
        }

        public static float TurnToGradian(float turn)
        {
            return turn*400;
        }

        public static Vector2 TurnToVector(float turn, float vectorLenght)
        {
            return RadianToVector(TurnToRadian(turn), vectorLenght);
        }

        /*GRADIAN CONVERSIONS*/
        public static float GradianToDegree(float gradians)
        {
            return gradians*0.9f;
        }

        public static float GradianToRadian(float gradians)
        {
            return gradians/200;
        }

        public static float GradianToTurn(float gradians)
        {
            return gradians / 400;
        }

        public static Vector2 GradianToVector(float gradians, float vectorLenght)
        {
            return new Vector2(vectorLenght * (float)Math.Cos(gradians), -vectorLenght * (float)Math.Sin(gradians));
        }

        /*VECTOR CONVERSIONS*/
        public static float VectorToRadian(Vector2 vector)
        {
            return (float) Math.Atan2(-vector.Y, vector.X);
        }

        public static float VectorToDegree(Vector2 vector)
        {
            return RadianToDegree(VectorToRadian(vector));
        }

        public static float VectorToTurn(Vector2 vector)
        {
            return RadianToTurn(VectorToRadian(vector));
        }

        public static float VectorToGradian(Vector2 vector)
        {
            return RadianToGradian(VectorToRadian(vector));
        }
    }
}
