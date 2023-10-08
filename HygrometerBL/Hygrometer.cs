﻿namespace HygrometerBL;
public static class Hygrometer
{
    // Справочник значений насыщающей упругости водяного пара над поверхностью воды при различных температурах.
    // [Температура] = Упругость водяного пара (гПа)
    private static readonly Dictionary<double, double> dict = new()
    {
        [14.1] = 16.079,
        [14.2] = 16.189,
        [14.3] = 16.289,
        [14.4] = 16.395,
        [14.5] = 16.501,
        [14.6] = 16.608,
        [14.7] = 16.716,
        [14.8] = 16.814,
        [14.9] = 16.933,
        [15] = 17.042,
        [15.1] = 17.152,
        [15.2] = 17.623,
        [15.3] = 17.374,
        [15.4] = 17.438,
        [15.5] = 17.599,
        [15.6] = 17.712,
        [15.7] = 17.826,
        [15.8] = 17.94,
        [15.9] = 18.055,
        [16] = 18.171,
        [16.1] = 18.282,
        [16.2] = 18.405,
        [16.3] = 18.522,
        [16.4] = 18.641,
        [16.5] = 18.76,
        [16.6] = 18.88,
        [16.7] = 19,
        [16.8] = 19.121,
        [16.9] = 19.243,
        [17] = 19.365,
        [17.1] = 19.488,
        [17.2] = 19.612,
        [17.3] = 19.737,
        [17.4] = 19.862,
        [17.5] = 19.988,
        [17.6] = 20.144,
        [17.7] = 20.242,
        [17.8] = 20.37,
        [17.9] = 20.498,
        [18] = 20.628,
        [18.1] = 20.758,
        [18.2] = 20.888,
        [18.3] = 21.02,
        [18.4] = 21.153,
        [18.5] = 21.286,
        [18.6] = 21.419,
        [18.7] = 21.554,
        [18.8] = 21.689,
        [18.9] = 21.825,
        [19] = 21.962,
        [19.1] = 22.099,
        [19.2] = 22.238,
        [19.3] = 22.377,
        [19.4] = 22.516,
        [19.5] = 22.657,
        [19.6] = 22.798,
        [19.7] = 22.94,
        [19.8] = 23.023,
        [19.9] = 23.226,
        [20] = 23.371,
        [20.1] = 23.516,
        [20.2] = 23.662,
        [20.3] = 23.809,
        [20.4] = 23.956,
        [20.5] = 24.105,
        [20.6] = 24.254,
        [20.7] = 24.404,
        [20.8] = 24.554,
        [20.9] = 24.706,
        [21] = 24.858,
        [21.1] = 25.012,
        [21.2] = 25.166,
        [21.3] = 25.32,
        [21.4] = 25.476,
        [21.5] = 25.632,
        [21.6] = 25.79,
        [21.7] = 25.948,
        [21.8] = 26.107,
        [21.9] = 26.267,
        [22] = 26.428,
        [22.1] = 26.59,
        [22.2] = 26.752,
        [22.3] = 26.915,
        [22.4] = 27.08,
        [22.5] = 27.245,
        [22.6] = 27.41,
        [22.7] = 27.578,
        [22.8] = 27.815,
        [22.9] = 27.914,
        [23] = 28.083,
        [23.1] = 28.253,
        [23.2] = 28.425,
        [23.3] = 28.597,
        [23.4] = 28.771,
        [23.5] = 28.945,
        [23.6] = 29.12,
        [23.7] = 29.296,
        [23.8] = 29.472,
        [23.9] = 29.65,
        [24] = 29.829,
        [24.1] = 30.009,
        [24.2] = 30.189,
        [24.3] = 30.371,
        [24.4] = 30.553,
        [24.5] = 30.737,
        [24.6] = 30.921,
        [24.7] = 31.106,
        [24.8] = 31.293,
        [24.9] = 31.48,
        [25] = 31.668,
        [25.1] = 31.858,
        [25.2] = 32.048,
        [25.3] = 32.239,
        [25.4] = 32.431,
        [25.5] = 32.625,
        [25.6] = 32.818,
        [25.7] = 33.014,
        [25.8] = 33.21,
        [25.9] = 33.408,
        [26] = 33.606,
        [26.1] = 33.805,
        [26.2] = 34.056,
        [26.3] = 34.207,
        [26.4] = 34.406,
        [26.5] = 34.612,
        [26.6] = 34.817,
        [26.7] = 34.229,
        [26.8] = 35.437,
        [26.9] = 35.641,
        [27] = 35.646,
        [27.1] = 35.856,
        [27.2] = 36.066,
        [27.3] = 36.279,
        [27.4] = 36.429,
        [27.5] = 36.706,
        [27.6] = 36.921,
        [27.7] = 37.137,
        [27.8] = 37.355,
        [27.9] = 37.573,
        [28] = 37.793,
        [28.1] = 38.014,
        [28.2] = 38.236,
        [28.3] = 38.459,
        [28.4] = 38.683,
        [28.5] = 38.908,
        [28.6] = 39.135,
        [28.7] = 39.362,
        [28.8] = 39.595,
        [28.9] = 39.821,
        [29] = 40.052,
        [29.1] = 40.284,
        [29.2] = 40.518,
        [29.3] = 40.475,
        [29.4] = 40.988,
        [29.5] = 41.225,
        [29.6] = 41.463,
        [29.7] = 41.702,
        [29.8] = 41.943,
        [29.9] = 42.184,
        [30] = 42.427,
        [30.1] = 42.671,
        [30.2] = 42.917,
        [30.3] = 43.163,
        [30.4] = 43.411,
        [30.5] = 43.66,
        [30.6] = 43.911,
        [30.7] = 44.162,
        [30.8] = 44.415,
        [30.9] = 44.669,
        [31] = 44.924,
        [31.1] = 45.181,
        [31.2] = 45.439,
        [31.3] = 45.698,
        [31.4] = 45.958,
        [31.5] = 46.22,
        [31.6] = 46.483,
        [31.7] = 46.747,
        [31.8] = 47.013,
        [31.9] = 47.28,
        [32] = 47.548,
        [32.1] = 47.817,
        [32.2] = 48.088,
        [32.3] = 48.36,
        [32.4] = 48.634,
        [32.5] = 48.909,
        [32.6] = 49.185,
        [32.7] = 49.463,
        [32.8] = 49.772,
        [32.9] = 50.022,
        [33] = 50.303,
        [33.1] = 50.587,
        [33.2] = 50.871,
        [33.3] = 51.157,
        [33.4] = 51.444,
        [33.5] = 51.733,
        [33.6] = 52.023,
        [33.7] = 52.314,
        [33.8] = 52.607,
        [33.9] = 52.901,
        [34] = 53.196,
        [34.1] = 53.494,
        [34.2] = 53.792,
        [34.3] = 54.092,
        [34.4] = 54.394,
        [34.5] = 54.697,
        [34.6] = 55,
        [34.7] = 55.036,
        [34.8] = 55.614,
        [34.9] = 55.927,
        [35] = 56.233,
        [35.1] = 56.545,
        [35.2] = 56.868,
        [35.3] = 57.173,
        [35.4] = 57.489,
        [35.5] = 57.807,
        [35.6] = 58.126,
        [35.7] = 58.447,
        [35.8] = 58.769,
        [35.9] = 59.093,
        [36] = 59.418
    };

    // A - Постоянная психометра.
    private const double A = 0.0007947;
    // P - Атмосферное давление (гПа).
    private const double P = 1000;

    /// <summary>
    /// Получить относительную влажность воздуха психометрическим методом.
    /// </summary>
    /// <param name="dryThermometer">Показание сухого термометра.</param>
    /// <param name="wetThermometer">Показание смоченного термометра.</param>
    /// <returns>Относительная влажность воздуха, %</returns>
    public static void PsychometricMethod(double dryThermometer, double wetThermometer, out double relativeHumidity)
    {
        // Проверить входные параметры.

        // E - Давление насыщения при температуре смоченного термометра, гПа.
        if (!dict.TryGetValue(wetThermometer, out double E))
        {
            wetThermometer = 15;
            E = dict[wetThermometer];
        }

        // Давление насыщения при температуре сухого термометра, гПа.
        if (!dict.TryGetValue(dryThermometer, out double e0))
        {
            dryThermometer = 15;
            e0 = dict[dryThermometer];
        }

        // Текущее давление водяного пара в воздухе, гПа.
        double e = E - A * (dryThermometer - wetThermometer) * P;

        // Относительная влажность воздуха, %
        double f = e / e0 * 100;

        f = Math.Round(f, 0); // Округление до целых.
        relativeHumidity = f;

        var excel = new ExcelFile();
        if (!excel.Test(dryThermometer, f))
        {
            relativeHumidity = 999;
        }
    }
}