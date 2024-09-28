
namespace TEST;
internal static partial class Program {
    static void Main(string[] args) {
        Time Time = new();

        PRINT("\n~~~ START ~~~");

        Test__Integer();

        Test__Vector();
        Test__Vector_Color();
        Test__Vector_Generate();
        Test__Vector_Interpolation();

        Test__String();

        PRINT("\n~~~ FINISH ~~~\n");

        Time.Update(); PRINT($" ** Time Elapsed: {Time.Seconds}\n");

    }
}
