package codingdojo;

import codingdojo.officecleaner1.OfficeCleaner1;
import codingdojo.officecleaner9.OfficeCleaner9;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.MethodSource;

import java.io.*;
import java.util.AbstractMap;
import java.util.Map;
import java.util.concurrent.Callable;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class OfficeCleanerTests {

    static Stream<Map.Entry<String, String>> stringProvider() {
        return Stream.of(
                new AbstractMap.SimpleEntry<>("Input_empty.txt",  "=> Cleaned: 1"),
                new AbstractMap.SimpleEntry<>("Input_one.txt",  "=> Cleaned: 1"),
                new AbstractMap.SimpleEntry<>("Input_given_sample.txt",  "=> Cleaned: 4"),
                new AbstractMap.SimpleEntry<>("Input_only_west.txt",  "=> Cleaned: 9"),
                new AbstractMap.SimpleEntry<>("Input_wiping.txt",  "=> Cleaned: 9"),
                new AbstractMap.SimpleEntry<>("Input_large.txt",  "=> Cleaned: 1047")
        );
    }

    private static void DoRobotCleanerTest(String filename, String expected, Runnable sut) throws Exception
    {
        var originalIn = System.in;
        var originalOut = System.out;
        try
        {
            ClassLoader classLoader = OfficeCleanerTests.class.getClassLoader();
            File file = new File(classLoader.getResource(filename).getFile());

            System.setIn(new FileInputStream(file));
            OutputStream baos = new ByteArrayOutputStream();
            PrintStream out = new PrintStream(baos);
            System.setOut(out);

            sut.run();

            out.flush();
            var output = baos.toString();
            assertEquals(expected, output.trim());
        }
        finally
        {
            System.setIn(originalIn);
            System.setOut(originalOut);
        }

    }

    @ParameterizedTest
    @MethodSource("stringProvider")
    public void OfficeCleaner1Test(Map.Entry<String, String> data) throws Exception
    {
        String filename = data.getKey();
        String expected = data.getValue();
        DoRobotCleanerTest(filename, expected, OfficeCleaner1::main);

    }

    @ParameterizedTest
    @MethodSource("stringProvider")
    public void OfficeCleaner9Test(Map.Entry<String, String> data) throws Exception
    {
        String filename = data.getKey();
        String expected = data.getValue();
        DoRobotCleanerTest(filename, expected, OfficeCleaner9::main);

    }

}
