import { useState } from 'react';
import { sendPrompt } from '../services/api';
import './PromptInput.css';

const PromptInput = () => {
  const [inputText, setInputText] = useState('');
  const [imageFile, setImageFile] = useState<File | null>(null);
  const [previewUrl, setPreviewUrl] = useState<string | null>(null);
  const [output, setOutput] = useState<string | null>(null);

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (!file) return;
    setImageFile(file);

    const reader = new FileReader();
    reader.onloadend = () => {
        if (reader.result && typeof reader.result === 'string') {
            setPreviewUrl(reader.result); // reader.result already includes prefix!
        }
    };
    reader.readAsDataURL(file); // this gives full data:image/... base64

  };

  const removeImage = () => {
    setImageFile(null);
    setPreviewUrl(null);
  };

  const submit = async () => {
    const result = await sendPrompt(inputText, previewUrl ?? undefined);
    setOutput(result);
  };

  const canSend = inputText.trim() !== '' || imageFile;

  return (
    <div className="promptBox">
      <textarea
        placeholder="Type your message..."
        value={inputText}
        onChange={(e) => setInputText(e.target.value)}
        className="inputBox"
        rows={4}
      />

      <div className="imageInputWrapper">
        <input
          type="file"
          accept="image/*"
          onChange={handleImageChange}
          className="fileInput"
        />
        {previewUrl && (
          <div className="imagePreview">
            <img src={previewUrl} alt="Preview" />
            <button className="removeBtn" onClick={removeImage}>
              ✖
            </button>
          </div>
        )}
      </div>

      <button
        className="submitBtn"
        onClick={submit}
        disabled={!canSend}
        title={canSend ? 'Send' : 'Enter text or upload image'}
      >
        ➤
      </button>

      {output && (
        <div className="output">
          <strong>Output:</strong>
          <p>{output}</p>
        </div>
      )}
    </div>
  );
};

export default PromptInput;