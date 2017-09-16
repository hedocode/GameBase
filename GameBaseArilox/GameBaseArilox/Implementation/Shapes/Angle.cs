using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Shapes
{
    public enum AngleType : byte
    {
        Degree,
        Radian,
        Turn,
        Gradian
    }
        
    public struct Angle
    {
        private float _degrees;

        public float Degrees
        {
            get { return _degrees; }
            set {
                if (value < 0)
                {
                    _degrees = value%361 + 360;
                }
                else
                {
                    _degrees = value % 361;
                }
            }
        }

        public float Radians
        {
            get { return AngleHelper.DegreeToRadian(Degrees); }
            set { Degrees = AngleHelper.RadianToDegree(value); }
        }

        public float Turn
        {
            get { return AngleHelper.DegreeToTurn(Degrees); }
            set { Degrees = AngleHelper.TurnToDegree(value); }
        }

        public float Gradians
        {
            get { return AngleHelper.DegreeToGradian(Degrees); }
            set { Degrees = AngleHelper.GradianToDegree(value); }
        }

        public Vector2 GetUnitVector() => AngleHelper.DegreeToVector(_degrees, 1);

        public Vector2 GetVector(float vectorLenght) => AngleHelper.DegreeToVector(_degrees, vectorLenght);


        public Angle(float value, AngleType angleType = AngleType.Degree)
        {
            switch (angleType)
            {
                case AngleType.Degree:
                    _degrees = value < 0 ? value%361 + 360 : value%361;
                    break;
                case AngleType.Gradian:
                    value = AngleHelper.GradianToDegree(value);
                    _degrees = value < 0 ? value % 361 + 360 : value % 361;
                    break;
                case AngleType.Radian:
                    value = AngleHelper.RadianToDegree(value);
                    _degrees = value < 0 ? value % 361 + 360 : value % 361;
                    break;
                case AngleType.Turn:
                    value = AngleHelper.TurnToDegree(value);
                    _degrees = value < 0 ? value % 361 + 360 : value % 361;
                    break;
                default:
                    _degrees = 0f;
                    break;
            }
        }

        public Angle(Vector2 vector)
        {
            _degrees = AngleHelper.RadianToDegree((float) Math.Atan2(-vector.Y, vector.X));
        }

        public float GetAngleIn(AngleType angleType)
        {
            switch (angleType)
            {
                case AngleType.Degree:
                    return Degrees;
                case AngleType.Gradian:
                    return Gradians;
                case AngleType.Radian:
                    return Radians;
                case AngleType.Turn:
                    return Turn;
                default:
                    return 0f;
            }
        }

        public bool Equals(Angle angle)
        {
            return Degrees.Equals(angle.Degrees);
        }

        public bool Equals(float value, AngleType angleType)
        {
            switch (angleType)
            {
                case AngleType.Degree:
                    return Degrees.Equals(value);
                case AngleType.Gradian:
                    return Gradians.Equals(value);
                case AngleType.Radian:
                    return Radians.Equals(value);
                case AngleType.Turn:
                    return Turn.Equals(value);
                default:
                    return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null,obj)) return false;
            return obj is Angle && Equals((Angle) obj);
        }

        public override int GetHashCode()
        {
            return Degrees.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_degrees} Degrees / {Radians} Rad / {Radians/AngleHelper.PiD} Pi / {Turn} Turn / {Gradians} Grad";
        }

        /*CAST OPERATOR*/
        public static explicit operator Angle(float degrees)
        {
            return new Angle(degrees);
        }

        public static implicit operator float(Angle angle)
        {
            return angle.Degrees;
        }

        /*BASIC OPERATORS*/
        public static Angle operator -(Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Degrees - angle2.Degrees);
        }

        public static Angle operator -(Angle angle1, float angle2)
        {
            return new Angle(angle1.Degrees - angle2);
        }

        public static Angle operator *(Angle angle, float multiplier)
        {
            return new Angle(angle.Degrees * multiplier);
        }

        public static Angle operator *(float multiplier, Angle angle)
        {
            return new Angle(angle.Degrees * multiplier);
        }

        public static Angle operator +(Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Degrees + angle2.Degrees);
        }

        public static Angle operator +(Angle angle1, float angle2)
        {
            return new Angle(angle1.Degrees + angle2);
        }

        public static Angle operator +(float angle1, Angle angle2)
        {
            return new Angle(angle1 + angle2.Degrees);
        }

        public static Angle operator /(Angle angle, float divider)
        {
            return new Angle(angle.Degrees / divider);
        }

        /*COMPARISON OPERATORS*/
        public static bool operator ==(Angle angle1, Angle angle2)
        {
            return angle1.Equals(angle2);
        }

        public static bool operator !=(Angle angle1, Angle angle2)
        {
            return !(angle1 == angle2);
        }

        public static bool operator ==(Angle angle1, float angle2)
        {
            return Math.Abs(angle1.Degrees - angle2) < 1/1000f;
        }

        public static bool operator !=(Angle angle1, float angle2)
        {
            return !(angle1 == angle2);
        }

        public static bool operator >(Angle angle1, Angle angle2)
        {
            return angle1.Degrees > angle2.Degrees;
        }

        public static bool operator <(Angle angle1, Angle angle2)
        {
            return angle1.Degrees < angle2.Degrees;
        }

        public static bool operator >(Angle angle1, float angle2)
        {
            return angle1.Degrees > angle2;
        }

        public static bool operator <(Angle angle1, float angle2)
        {
            return angle1.Degrees < angle2;
        }

        public static bool operator >=(Angle angle1, Angle angle2)
        {
            return angle1.Degrees >= angle2.Degrees;
        }

        public static bool operator <=(Angle angle1, Angle angle2)
        {
            return angle1.Degrees <= angle2.Degrees;
        }

        public static bool operator >=(Angle angle1, float angle2)
        {
            return angle1.Degrees >= angle2;
        }

        public static bool operator <=(Angle angle1, float angle2)
        {
            return angle1.Degrees <= angle2;
        }
    }
}
