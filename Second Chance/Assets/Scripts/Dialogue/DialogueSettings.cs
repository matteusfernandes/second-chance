using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
  [Header("Settings")]
  public GameObject actor;

  [Header("Dialogue")]
  public Sprite speakerSprite;
  public string sentence;

  public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences {
  public string actorName;
  public Sprite profile;
  public Languages sentence;
};

[System.Serializable]
public class Languages {
  public string portuguese;
  public string english;
  public string spanish;
};

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor {
  public override void OnInspectorGUI() {
    DrawDefaultInspector();

    DialogueSettings dialogueSettings = (DialogueSettings)target;
    Languages languages = new Languages();
    Sentences sentences = new Sentences();

    languages.portuguese = dialogueSettings.sentence;
    sentences.profile = dialogueSettings.speakerSprite;
    sentences.sentence = languages;

    if (GUILayout.Button("Create Dialogue")) {
      if (dialogueSettings.sentence != "") {
        dialogueSettings.dialogues.Add(sentences);
        dialogueSettings.speakerSprite = null;
        dialogueSettings.sentence = "";
      };
    };
  }
};
#endif
