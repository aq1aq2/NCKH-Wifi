package ctu.nckh.wifiquaman.activity;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.net.wifi.ScanResult;
import android.net.wifi.WifiManager;

import java.util.List;

public class GetWifiInfo {
    WifiManager wifi;
    String wifis[];
    WifiScanReceiver wifiReciever;

    public String[] getWifiInfos(){
        return wifis;
    }

    public static void main(String[] args) {
        
    }

    private class WifiScanReceiver extends BroadcastReceiver {
        public void onReceive(Context c, Intent intent) {
            List<ScanResult> wifiScanList = wifi.getScanResults();
            wifis = new String[wifiScanList.size()];

            for(int i = 0; i < wifiScanList.size(); i++){
                wifis[i] = ((wifiScanList.get(i)).toString());
            }
        }
    }
}
