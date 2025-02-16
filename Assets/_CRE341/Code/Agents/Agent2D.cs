using System;

// Assuming you have a Vector2D and BaseGameEntity class (or equivalent)
// You might need to adjust these based on your project's setup.  I'll
// provide basic implementations below for completeness.
namespace agentFundamentals
public class Vector2D
{
    public double X { get; set; }
    public double Y { get; set; }

    public Vector2D(double x = 0, double y = 0)
    {
        X = x;
        Y = y;
    }

    // Add other Vector2D methods as needed (e.g., Normalize, Dot, Cross, etc.)
    // For example:
     public void Normalize()
    {
        double magnitude = Math.Sqrt(X * X + Y * Y);
        if (magnitude > 0)
        {
            X /= magnitude;
            Y /= magnitude;
        }
    }

    public static Vector2D operator +(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2D operator -(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector2D operator *(Vector2D v, double scalar)
    {
        return new Vector2D(v.X * scalar, v.Y * scalar);
    }
    public static Vector2D operator /(Vector2D v, double scalar)
    {
       if (scalar == 0)
        {
            throw new DivideByZeroException("Cannot divide a vector by zero.");
        }
        return new Vector2D(v.X / scalar, v.Y / scalar);
    }
}

public class BaseGameEntity
{
    public int ID { get; set; } // Example property.  Add others as needed.
    // ... other base entity properties and methods ...

    private static int nextValidID = 0;
     public BaseGameEntity()
    {
        ID = nextValidID++;
    }
}
public class MovingEntity : BaseGameEntity
{
    private Vector2D m_vVelocity;
    private Vector2D m_vHeading;
    private Vector2D m_vSide;
    private double m_dMass;
    private double m_dMaxSpeed;
    private double m_dMaxForce;
    private double m_dMaxTurnRate;


    // Properties (C#-style accessors) - MUCH BETTER than public fields
    public Vector2D Velocity
    {
        get { return m_vVelocity; }
        set { m_vVelocity = value; }
    }

    public Vector2D Heading
    {
        get { return m_vHeading; }
        set { m_vHeading = value;  /* Consider normalizing here */ }
    }
    public Vector2D Side
    {
        get { return m_vSide; }
        set { m_vSide = value;}  //should be perpendicular.
    }

    public double Mass
    {
        get { return m_dMass; }
        set { m_dMass = value; }
    }

    public double MaxSpeed
    {
        get { return m_dMaxSpeed; }
        set { m_dMaxSpeed = value; }
    }

    public double MaxForce
    {
        get { return m_dMaxForce; }
        set { m_dMaxForce = value; }
    }

public double MaxTurnRate
{
    get { return m_dMaxTurnRate; }
    set { m_dMaxTurnRate = value; }
}

public Vector2D Position { get; set; }
// Constructors
public MovingEntity()
    {
        m_vVelocity = new Vector2D();
        m_vHeading = new Vector2D();
        m_vSide = new Vector2D();
        m_dMass = 1.0;          // Default values
        m_dMaxSpeed = 10.0;
        m_dMaxForce = 100.0;
        m_dMaxTurnRate = 1.0;
    }
    public MovingEntity(double mass, double maxSpeed, double maxForce, double maxTurnRate, Vector2D initialVelocity, Vector2D initialHeading)
    {
        m_vVelocity = initialVelocity;
        m_vHeading = initialHeading;
        CalculateSideVector();
        m_dMass = mass;
        m_dMaxSpeed = maxSpeed;
        m_dMaxForce = maxForce;
        m_dMaxTurnRate = maxTurnRate;

    }

    //Helper function to calculate side vector, based on heading.
    private void CalculateSideVector()
    {
        // Assuming a 2D environment.  For 3D, you'd use a cross product.
        m_vSide = new Vector2D(-m_vHeading.Y, m_vHeading.X);
    }

    //You'd likely need other methods, like Update(), to handle movement.
    //For example (very basic):
    public void Update(double deltaTime)
    {
      //Simple Newtonian physics
        Vector2D steeringForce = TruncateForce(CalculateSteeringForce(), MaxForce); //Placeholder for force calculation
        Vector2D acceleration = steeringForce / Mass;
        Velocity = Velocity + acceleration * deltaTime;

        // Make sure velocity doesn't exceed max speed
        if (Velocity.X * Velocity.X + Velocity.Y * Velocity.Y > MaxSpeed * MaxSpeed)
        {
          Velocity.Normalize();
          Velocity = Velocity * MaxSpeed;

        }

        // Update position (you would have a position property in BaseGameEntity)
        // Assuming BaseGameEntity has a Position property:
        // Position += Velocity * deltaTime;   //VERY IMPORTANT.

         // Update heading if there's velocity
        if (Velocity.X * Velocity.X + Velocity.Y * Velocity.Y > double.Epsilon) // Avoid division by zero
        {
            Heading = new Vector2D(Velocity.X, Velocity.Y);
            Heading.Normalize();
            CalculateSideVector();
        }
    }

     private Vector2D TruncateForce(Vector2D force, double max)
    {
        if (force.X * force.X + force.Y * force.Y > max * max)
        {
            force.Normalize();
            force *= max;
        }
        return force;
    }


    //Placeholder
    protected virtual Vector2D CalculateSteeringForce()
    {
        //VERY basic steering:  Move towards a target, for example.
        //This is where you'd implement steering behaviors (Seek, Flee, Arrive, etc.)

        //Example:  Seek a target position.  You'd likely have a TargetPosition property.
        //Vector2D desiredVelocity = TargetPosition - Position;
        //desiredVelocity.Normalize();
        //desiredVelocity *= MaxSpeed;
        //return desiredVelocity - Velocity;

        return new Vector2D(0, 0); // No force by default.
    }

        public Vector2D Seek(Vector2D targetPos)
        {
            // Calculate the desired velocity:  (TargetPos - CurrentPos), normalized, and scaled to max speed.
            Vector2D desiredVelocity = targetPos - Position;
            desiredVelocity.Normalize();
            desiredVelocity *= MaxSpeed;

            // Calculate the steering force:  (DesiredVelocity - CurrentVelocity)
            return desiredVelocity - Velocity;
        }

        public Vector2D Flee(Vector2D targetPos)
        {
            // Calculate the desired velocity:  (CurrentPos - TargetPos), normalized, and scaled to max speed.
            Vector2D desiredVelocity = Position - targetPos;
            desiredVelocity.Normalize();
            desiredVelocity *= MaxSpeed;

            // Calculate the steering force:  (DesiredVelocity - CurrentVelocity)
            return desiredVelocity - Velocity;
        }


}