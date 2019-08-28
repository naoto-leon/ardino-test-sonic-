# ardino-test-sonic-
osc saver 

#### Sonic_piとのOsc通信について
#### [こちらの記事の補足になります。](https://github.com/naoto-leon/VR-test-5-Backup3-2-master)
*** 

Sonic_piはRubyで作る音楽ソフトですが、それのOsc通信に関して記事もほとんどないので書き置きしとく。

まず、既にportが決まっている。(笑)  
saver側となる場合は好きにportを決められますが、受信側は4559を使わないとダメです。  
そして受信可能のチェックを入れて。　

  val = sync"/"から続くアドレスを念頭に打ち込むだけ。  
  
<img width="653" alt="sonic1" src="https://user-images.githubusercontent.com/43961147/63844549-61e95c80-c9c3-11e9-9768-cd5c45b2f26c.png">

注意点としては、loopの中で使用しないと値を継続して受け取れないこと。その他のoscでvoid startで受け取らないのと同じ感じ。  
おすすめは受け取った値を変数なり関数なりに一度してしまい、使い回すこと。　

##### 参考コード　

    ##| use_debug false



    define :bpm do
  
      val = sync"/aaa/aaa/aaaa"
      use_bpm val[0]

    end

    notes = (scale :f2, :minor_pentatonic, num_octaves: 2).shuffle

    live_loop :industry do
     bpm
    sample :loop_industrial, beat_stretch: 1
     sleep 1
     end
 
    live_loop :drive do
     bpm
     sample :bd_haus, amp: 5
     sleep 0.5
    end


    live_loop :locom do
     bpm
     sample :loop_compus, amp: 6
     sleep 10
    end

    live_loop :melow do
      bpm
      use_synth :fm
      use_synth_defaults release: rrand(1,1.25),amp: rrand(3,4)
     with_fx :reverb, mix: 0.8 do
    
    
    play chord(:C4, :minor7)
    ##| play_pattern_timed chord(:C, :minor7),[0.2]
    sleep 2
    play chord(:A4, :minor7)
    ##| play_pattern_timed chord(:A, :minor7),[0.2]
    sleep 2
    play chord(:E4, :minor7)
    sleep 1.5
    play chord(:G4, :minor7)
    sleep 2
    play  chord(:C4, :major7)
    sleep 1
    play chord(:D4,:minor7)
    sleep 1
    play chord(:E4,:major7)
    sleep 2
    play chord(:A4, :minor7)
    sleep 1.5
    play chord(:D4, :major7)
    sleep 1
    play chord(:D4, :minor7)
    sleep 1
    play chord(:G4, :major)
    sleep 1.5
     end
     sleep 1
    end


    live_loop :guitf do
      bpm
      sample :guit_e_slide, rate: 1, amp: 0.4
      sleep 2
    end

    live_loop :hermoni do
     bpm
      sample :guit_harmonics, rate: 0.2, amp: 0.2
     sleep 8.5
    end



    live_loop :sc do
     bpm
      play_pattern_timed scale(:c3, :minor_pentatonic, num_octaves: 3), 0.125, release: 0.5, amp: 0.3
     sleep 0.25
    end

    live_loop :scca do
      bpm
      play choose(chord(:C4,:minor7)),release: 0.1, cutooff: rrand(10, 30)
     sleep 0.25
    end
