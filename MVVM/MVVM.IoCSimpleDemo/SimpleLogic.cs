namespace IoCSimpleDemo
{
    public class SimpleLogic
    {
        ILogger logger;

        public SimpleLogic(ILogger logger)
        {
            this.logger = logger;
        }

        public int Sum(int a, int b)
        {
            logger.Write($"Вычисление суммы { a } и { b } запущено");
            var c = a + b;
            logger.Write($"Сумма { a } и { b } успешно вычислена");
            return c;
        }
    }
}