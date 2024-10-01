
namespace TEST;
internal static partial class Program {
    static void Main(string[] args) {
        PRINT("\n~~~ START ~~~");
        Time Time = new();

        Test__Integer();

        Test__String();

        Test__Vector();
        Test__Vector_Color();
        Test__Vector_Generate();
        Test__Vector_Interpolation();

        Time.Update();
        PRINT("\n~~~ FINISH ~~~");
        PRINT($"\n ** Time Elapsed: {Time.Seconds}\n");
    }
}
