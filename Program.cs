
namespace TEST;
internal static partial class Program {
    static void Main(string[] args) {
        Time Time = new();

        PRINT("\n~~~ START ~~~");

        Test__Integer();

        Test__Vector_Color();
        Test__Vector_Generate();
        Test__Vector_Interpolation();

        Test__String();

        Time.Update(); PRINT($"\n ** Time Elapsed: {Time.Seconds}");

        PRINT("\n~~~ FINISH ~~~\n");
    }
}
