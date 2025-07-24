const API_BASE_URL = import.meta.env.VITE_API_URL;

export const sendPrompt = async (text: string, imageBase64?: string) => {
  // If no image, use GET endpoint for text
  if (!imageBase64) {
    const res = await fetch(
      `${API_BASE_URL}/api/captions/from-text?text=${encodeURIComponent(text)}`
    );

    if (!res.ok) throw new Error('Text caption request failed');
    return res.text();
  }

  // If image is provided, use POST endpoint
  const payload = {
    text,
    imageBase64
  };

  const res = await fetch(`${API_BASE_URL}/api/captions/from-image`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload)
  });

  if (!res.ok) throw new Error('Image caption request failed');
  return res.text();
};
