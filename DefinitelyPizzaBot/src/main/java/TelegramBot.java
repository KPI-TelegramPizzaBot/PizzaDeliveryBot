import org.telegram.telegrambots.ApiContextInitializer;
import org.telegram.telegrambots.bots.TelegramLongPollingBot;
import org.telegram.telegrambots.meta.TelegramBotsApi;
import org.telegram.telegrambots.meta.api.methods.send.SendDocument;
import org.telegram.telegrambots.meta.api.methods.send.SendMessage;
import org.telegram.telegrambots.meta.api.methods.send.SendPhoto;
import org.telegram.telegrambots.meta.api.objects.Message;
import org.telegram.telegrambots.meta.api.objects.Update;
import org.telegram.telegrambots.meta.exceptions.TelegramApiException;


import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
//import org.apache.log4j.*;



public class TelegramBot extends TelegramLongPollingBot {

    //example Start
    public static void main(String[] args) {
        ApiContextInitializer.init();
        TelegramBotsApi botapi = new TelegramBotsApi();
        try {
            botapi.registerBot(new TelegramBot());
        } catch (TelegramApiException e) {
            e.printStackTrace();
        }
    }

    //example answer TEXT
    public void sendTextMsg(Message msg, String text) {
        try {
            execute(new SendMessage().setChatId(msg.getChatId()).setText(text));
        }
        catch (Exception e) {
            System.err.println(e.getMessage());
        }
    }

    //example answer GIF
    public void sendGIFMsg(Message msg, String gif) {
        try {
            execute(new SendDocument().setChatId(msg.getChatId()).setDocument(gif));
        } catch (Exception e) {
//            LOG.error("Can't send GIF message: ", e);
        }
    }

    //example answer IMAGE
    public void sendImageMsg(Message msg, String image) {
        try {
            execute(new SendPhoto().setChatId(msg.getChatId()).setPhoto(image));
        } catch (Exception e) {
//            LOG.error("Can't send Photo message: ", e);
        }
    }


    public void onUpdateReceived(Update update) {
        PizzaAPI api = new PizzaAPI();
        try {
            sendTextMsg(update.getMessage(), api.GetSomeInformation());
        }
        catch (Exception e) {
            System.err.println(e.getMessage());
        }
        System.out.println("recieved");
    }


    public String getBotUsername() {
        return "DefinitelyPizzaBot";
    }

    @Override
    public String getBotToken() {
        return "692413877:AAG-dl68YscsdPEguKl7vq7cLo6hevJthpQ";
    }
}