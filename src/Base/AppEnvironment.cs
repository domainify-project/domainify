namespace Domainify
{
    /// <summary>
    /// Represents the environment of the application.
    /// </summary>
    public class AppEnvironment
    {
        private static EnvironmentState? _state = null;

        /// <summary>
        /// Gets the current environment state of the application.
        /// </summary>
        public static EnvironmentState State
        {
            get
            {
                // If the state has not been determined yet, try to parse it from the environment variable.
                if (_state == null)
                {
                    Enum.TryParse(
                        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), out EnvironmentState state);
                    _state = state;
                }

                return (EnvironmentState)_state!;
            }
        }
    }

    /// <summary>
    /// Represents the possible states of the application environment.
    /// </summary>
    public enum EnvironmentState
    {
        Production,
        Development,
        Staging,
    }
}
